USE [autologia]
GO
/****** Object:  StoredProcedure [auto].[spGetAllCars]    Script Date: 26/03/2018 15:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Oren
-- Create date: 26/03/2018
-- Description:	Get all cars
-- =============================================
ALTER PROCEDURE [auto].[spGetAllCars] 
AS
BEGIN
	SELECT a.ID, b.NAME MANUFACTOR, c.NAME MAIN_TYPE, d.NAME SUB_TYPE
	FROM auto.Cars a
		join auto.CarManufactors b on a.Manufactor = b.ID
		join auto.Answers c on a.Main_Type = c.ID
		join auto.Answers d on a.Sub_Type = d.ID
	ORDER BY ID DESC
END
