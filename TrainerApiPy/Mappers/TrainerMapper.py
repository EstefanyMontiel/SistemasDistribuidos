from Trainerpb.trainer_pb2 import TrainerResponse, CreateTrainersResponse
from Models.Trainer import Trainer
from google.protobuf.timestamp_pb2 import Timestamp

def toResponse(tra: Trainer) -> TrainerResponse:
    return TrainerResponse(
        id=tra.id,
        name=tra.name,
        age=tra.age,
        birthdate=tra.birthdate,
        medals=tra.medals,
        created_at=tra.created_at
    )

def toCreateResponse(trainers: list[Trainer]) -> CreateTrainersResponse:
    return CreateTrainersResponse(
        success_count=len(trainers),
        trainers=[toResponse(t) for t in trainers]
    )