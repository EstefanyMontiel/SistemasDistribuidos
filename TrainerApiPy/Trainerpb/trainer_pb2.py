# -*- coding: utf-8 -*-
# Generated by the protocol buffer compiler.  DO NOT EDIT!
# NO CHECKED-IN PROTOBUF GENCODE
# source: trainer.proto
# Protobuf Python Version: 5.29.0
"""Generated protocol buffer code."""
from google.protobuf import descriptor as _descriptor
from google.protobuf import descriptor_pool as _descriptor_pool
from google.protobuf import runtime_version as _runtime_version
from google.protobuf import symbol_database as _symbol_database
from google.protobuf.internal import builder as _builder
_runtime_version.ValidateProtobufRuntimeVersion(
    _runtime_version.Domain.PUBLIC,
    5,
    29,
    0,
    '',
    'trainer.proto'
)
# @@protoc_insertion_point(imports)

_sym_db = _symbol_database.Default()


from google.protobuf import timestamp_pb2 as google_dot_protobuf_dot_timestamp__pb2


DESCRIPTOR = _descriptor_pool.Default().AddSerializedFile(b'\n\rtrainer.proto\x12\ttrainerpb\x1a\x1fgoogle/protobuf/timestamp.proto\"(\n\x18GetTrainersByNameRequest\x12\x0c\n\x04name\x18\x01 \x01(\t\"]\n\x16\x43reateTrainersResponse\x12\x15\n\rsuccess_count\x18\x01 \x01(\x05\x12,\n\x08trainers\x18\x02 \x03(\x0b\x32\x1a.trainerpb.TrainerResponse\"\x83\x01\n\x14\x43reateTrainerRequest\x12\x0c\n\x04name\x18\x01 \x01(\t\x12\x0b\n\x03\x61ge\x18\x02 \x01(\x05\x12-\n\tbirthdate\x18\x03 \x01(\x0b\x32\x1a.google.protobuf.Timestamp\x12!\n\x06medals\x18\x04 \x03(\x0b\x32\x11.trainerpb.Medals\" \n\x12TrainerByIdRequest\x12\n\n\x02id\x18\x01 \x01(\t\"\xba\x01\n\x0fTrainerResponse\x12\n\n\x02id\x18\x01 \x01(\t\x12\x0c\n\x04name\x18\x02 \x01(\t\x12\x0b\n\x03\x61ge\x18\x03 \x01(\x05\x12-\n\tbirthdate\x18\x04 \x01(\x0b\x32\x1a.google.protobuf.Timestamp\x12!\n\x06medals\x18\x05 \x03(\x0b\x32\x11.trainerpb.Medals\x12.\n\ncreated_at\x18\x06 \x01(\x0b\x32\x1a.google.protobuf.Timestamp\"<\n\x06Medals\x12\x0e\n\x06region\x18\x01 \x01(\t\x12\"\n\x04type\x18\x02 \x01(\x0e\x32\x14.trainerpb.MedalType*9\n\tMedalType\x12\n\n\x06UNKNOW\x10\x00\x12\x08\n\x04GOLD\x10\x01\x12\n\n\x06SILVER\x10\x02\x12\n\n\x06\x42RONZE\x10\x03\x32\x88\x02\n\x0eTrainerService\x12G\n\nGetTrainer\x12\x1d.trainerpb.TrainerByIdRequest\x1a\x1a.trainerpb.TrainerResponse\x12U\n\rCreateTrainer\x12\x1f.trainerpb.CreateTrainerRequest\x1a!.trainerpb.CreateTrainersResponse(\x01\x12V\n\x11GetTrainersByName\x12#.trainerpb.GetTrainersByNameRequest\x1a\x1a.trainerpb.TrainerResponse0\x01\x42\r\xaa\x02\nTrainerApib\x06proto3')

_globals = globals()
_builder.BuildMessageAndEnumDescriptors(DESCRIPTOR, _globals)
_builder.BuildTopDescriptorsAndMessages(DESCRIPTOR, 'trainer_pb2', _globals)
if not _descriptor._USE_C_DESCRIPTORS:
  _globals['DESCRIPTOR']._loaded_options = None
  _globals['DESCRIPTOR']._serialized_options = b'\252\002\nTrainerApi'
  _globals['_MEDALTYPE']._serialized_start=617
  _globals['_MEDALTYPE']._serialized_end=674
  _globals['_GETTRAINERSBYNAMEREQUEST']._serialized_start=61
  _globals['_GETTRAINERSBYNAMEREQUEST']._serialized_end=101
  _globals['_CREATETRAINERSRESPONSE']._serialized_start=103
  _globals['_CREATETRAINERSRESPONSE']._serialized_end=196
  _globals['_CREATETRAINERREQUEST']._serialized_start=199
  _globals['_CREATETRAINERREQUEST']._serialized_end=330
  _globals['_TRAINERBYIDREQUEST']._serialized_start=332
  _globals['_TRAINERBYIDREQUEST']._serialized_end=364
  _globals['_TRAINERRESPONSE']._serialized_start=367
  _globals['_TRAINERRESPONSE']._serialized_end=553
  _globals['_MEDALS']._serialized_start=555
  _globals['_MEDALS']._serialized_end=615
  _globals['_TRAINERSERVICE']._serialized_start=677
  _globals['_TRAINERSERVICE']._serialized_end=941
# @@protoc_insertion_point(module_scope)
