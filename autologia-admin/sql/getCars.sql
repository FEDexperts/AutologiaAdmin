SELECT
    Cars.ID,
    CarManufactors.[NAME] MANUFACTOR_DESC,
    CarModel.[NAME] MODEL_DESC,
    CarSubModel.[NAME] SUB_MODEL_DESC,
    CarMainType.[DESCRIPTION] MAIN_TYPE_DESC,
    --SubType.[DESCRIPTION] SUB_TYPE_DESC,
    CarSubModel.SMALL_IMAGE
  FROM Cars
       JOIN CarManufactors ON Cars.MANUFACTOR = CarManufactors.ID
       JOIN CarModel ON Cars.[MODEL] = CarModel.ID and CarManufactors.ID = CarModel.MANUFACTOR_ID
       JOIN CarSubModel ON Cars.SUB_MODEL = CarSubModel.ID and CarModel.ID = CarSubModel.MODEL_ID and CarManufactors.ID = CarSubModel.MANUFACTOR_ID
       JOIN CarMainType ON Cars.MAIN_TYPE = CarMainType.ID
       --JOIN Menu SubType ON Cars.SUB_TYPE = SubType.ID and SubType.PARENT_ID = 13