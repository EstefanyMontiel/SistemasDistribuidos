import time
from concurrent import futures

import grpc
from google.protobuf.timestamp_pb2 import Timestamp
from Trainerpb.trainer_pb2_grpc import TrainerServiceServicer, add_TrainerServiceServicer_to_server
from Trainerpb.trainer_pb2 import TrainerByIdRequest, CreateTrainerRequest, GetTrainersByNameRequest


from Repositories.TrainerRepository import TrainerRepository
from Mappers.TrainerMapper import toResponse, toCreateResponse


class TrainerService(TrainerServiceServicer):
    def __init__(self, repo: TrainerRepository):
        self.repo = repo

    def GetTrainer(self, request: TrainerByIdRequest, context):
        trainer = self.repo.GetTrainerById(request.id)
        if not trainer:
            context.set_code(grpc.StatusCode.NOT_FOUND)
            context.set_details(f"Trainer {request.id} no encontrado")
            return toResponse(trainer(
                id=request.id, name="", age=0,
                birthdate=None, medals=[], created_at=None
            ))
        return toResponse(trainer)

    def CreateTrainer(self, request_iterator, context):
        created = []
        for req in request_iterator:  # stream de CreateTrainerRequest
            tr = self.repo.CreateTrainer(
                name=req.name,
                age=req.age,
                birthdate=req.birthdate,
                medals=list(req.medals)
            )
            created.append(tr)
        return toCreateResponse(created)

    def GetTrainersByName(self, request: GetTrainersByNameRequest, context):
        trainers = self.repo.GetTrainersByName(request.name)
        if not trainers:
            context.set_code(grpc.StatusCode.NOT_FOUND)
            context.set_details(f"Entrenador con nombre {request.name} no encontrado")
            return
        for trainer in trainers:
            yield toResponse(trainer)


def serve():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=4))
    repo = TrainerRepository()
    add_TrainerServiceServicer_to_server(TrainerService(repo), server)  
    server.add_insecure_port('[::]:50052')
    server.start()
    print("Servidor gRPC escuchando en localhost:50052")
    try:
        while True:
            time.sleep(86400)
    except KeyboardInterrupt:
        server.stop(0)

if __name__ == '__main__':
    serve()