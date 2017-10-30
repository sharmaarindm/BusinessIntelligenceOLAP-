-- File Name - storedProc.sql
-- Programers Name  - Arindm Sharma and Zivojin Pecin
-- Project - PROG - 3240 A2
-- Description - sql script in order to create the stored procedures for the yoyodb;

use YoYoDB;
-------------------------------------------------
GO
Create Procedure totalPartsMolded
@ProdID int
AS
BEGIN
DECLARE @partCount INT;
if(@ProdID = 0)
begin
SET @partCount = (Select count (ProductStatus) from CurrentProduction where ProductStatus = 'MOLD');
end
else
begin
SET @partCount = (Select count (ProductStatus) from CurrentProduction where ProductStatus = 'MOLD' AND ProductID = @ProdID);
end
RETURN @partCount;
END


GO
Create Procedure partsSuccessfullyPainted
@ProdID INT
AS
BEGIN
DECLARE @partsSuccessfullyPainted INT;
if(@ProdID = 0)
begin
SET @partsSuccessfullyPainted = (Select count (ProductStatus) from CurrentProduction where ProductStatus = 'QUEUE_ASSEMBLY');
end
else
begin
SET @partsSuccessfullyPainted = (Select count (ProductStatus) from CurrentProduction where ProductStatus = 'QUEUE_ASSEMBLY' AND ProductID = @ProdID);
end
RETURN @partsSuccessfullyPainted;
END



GO
Create Procedure partsSuccessfullyAssembled
@ProdID INT
AS
BEGIN
DECLARE @partsSuccessfullyAssemlbd INT;
if(@ProdID = 0)
begin
SET @partsSuccessfullyAssemlbd = (Select count (ProductStatus) from CurrentProduction where ProductStatus = 'PACKAGE');
end
else
begin
SET @partsSuccessfullyAssemlbd = (Select count (ProductStatus) from CurrentProduction where ProductStatus ='PACKAGE' AND ProductID = @ProdID);
end
RETURN @partsSuccessfullyAssemlbd;
END



GO
Create Procedure partsPackaged
@ProdID INT
AS
BEGIN
DECLARE @partsSuccessfullyPackaged INT;
if(@ProdID = 0)
begin
SET @partsSuccessfullyPackaged = (Select count (ProductStatus) from CurrentProduction where ProductStatus = 'PACKAGE');
end

else
begin
SET @partsSuccessfullyPackaged = (Select count (ProductStatus) from CurrentProduction where ProductStatus = 'PACKAGE' AND ProductID = @ProdID);
end
RETURN @partsSuccessfullyPackaged;
END




GO
Create Procedure totalPartsSuccessfullyMolded
@ProdID int
AS
BEGIN
DECLARE @totalPartsMolded INT;
if(@ProdID = 0)
begin
SET @totalPartsMolded = (Select count (ProductStatus) from CurrentProduction where ProductStatus = 'QUEUE_PAINT');
end
else
BEGIN
SET @totalPartsMolded = (Select count (ProductStatus) from CurrentProduction where ProductStatus = 'QUEUE_PAINT' AND ProductID = @ProdID);
end
RETURN @totalPartsMolded;
END



GO
Create Procedure partsMoldedY1
@ProdID INT
AS
BEGIN
DECLARE @retVal FLOAT;

if (@ProdID = 0)
begin
SET @retVal = (Select count (ProductID) from CurrentProduction where ProductStatus = 'MOLD');
end
else
begin
SET @retVal = (Select count (ProductID) from CurrentProduction where ProductStatus = 'MOLD' AND ProductID = @ProdID);
end

RETURN @retVal;

END

GO
Create Procedure partsMoldedY2
@ProdID INT
AS
BEGIN
DECLARE @retVal FLOAT;

if (@ProdID = 0)
begin
SET @retVal = (Select count (ProductID) from CurrentProduction where ProductStatus = 'PACKAGE');
end
else
begin
SET @retVal = (Select count (ProductID) from CurrentProduction where ProductStatus = 'PACKAGE' AND ProductID = @ProdID);
end

RETURN @retVal;

END



GO
Create Procedure yieldAtPaintY1
@ProdID INT
AS
BEGIN
DECLARE @retVal FLOAT;

if (@ProdID = 0)
begin
SET @retVal = (Select count (ProductID) from CurrentProduction where ProductStatus = 'QUEUE_PAINT');
end
else
begin
SET @retVal = (Select count (ProductID) from CurrentProduction where ProductStatus = 'QUEUE_PAINT' AND ProductID = @ProdID);
end

RETURN @retVal;

END

GO
Create Procedure yieldAtPaintY2
@ProdID INT
AS
BEGIN
DECLARE @retVal FLOAT;

if (@ProdID = 0)
begin
SET @retVal = (Select count (ProductID) from CurrentProduction where ProductStatus = 'QUEUE_ASSEMBLY');
end
else
begin
SET @retVal = (Select count (ProductID) from CurrentProduction where ProductStatus = 'QUEUE_ASSEMBLY' AND ProductID = @ProdID);
end

RETURN @retVal;

END




GO
Create Procedure yieldAtMoldY1
@ProdID INT
AS
BEGIN
DECLARE @retVal FLOAT;

if (@ProdID = 0)
begin
SET @retVal = (Select count (ProductID) from CurrentProduction where ProductStatus = 'QUEUE_PAINT');
end
else
begin
SET @retVal = (Select count (ProductID) from CurrentProduction where ProductStatus = 'QUEUE_PAINT' AND ProductID = @ProdID);
end

RETURN @retVal;
END

GO
Create Procedure yieldAtMoldY2
@ProdID INT
AS
BEGIN
DECLARE @retVal FLOAT;

if (@ProdID = 0)
begin
SET @retVal = (Select count (ProductID) from CurrentProduction where ProductStatus = 'MOLD');
end
else
begin
SET @retVal = (Select count (ProductID) from CurrentProduction where ProductStatus = 'MOLD' AND ProductID = @ProdID);
end

RETURN @retVal;
END






GO 
Create Procedure yieldAtAssebmlyY1
@ProdID INT
AS
BEGIN
DECLARE @retVal FLOAT;

if (@ProdID = 0)
begin
SET @retVal = (Select count (ProductID) from CurrentProduction where ProductStatus = 'PACKAGE');
end
else
begin
SET @retVal = (Select count (ProductID) from CurrentProduction where ProductStatus = 'PACKAGE ' AND ProductID = @ProdID);
end

RETURN @retVal;
END

GO 
Create Procedure yieldAtAssebmlyY2
@ProdID INT
AS
BEGIN
DECLARE @retVal FLOAT;

if (@ProdID = 0)
begin
SET @retVal = (Select count (ProductID) from CurrentProduction where ProductStatus = 'QUEUE_ASSEMBLY');
end
else
begin
SET @retVal = (Select count (ProductID) from CurrentProduction where ProductStatus = 'QUEUE_ASSEMBLY' AND ProductID = @ProdID);
end

RETURN @retVal;
END







----------------------------------------------------




GO
Create Procedure howManyFinalCoatFlaw
@ProdID INT
AS
BEGIN
DECLARE @retVal INT;
if(@ProdID = 0)
begin
SET @retVal = (Select count (ProductID) from CurrentProduction where Reason = 'FINAL_COAT_FLAW');
end
else
begin
SET @retVal = (Select count (ProductID) from CurrentProduction where Reason = 'FINAL_COAT_FLAW' AND ProductID = @ProdID);
end
RETURN @retVal;
END


GO
Create Procedure howManyBrokenShell
@ProdID INT
AS
BEGIN
DECLARE @retVal INT;
if (@ProdID = 0)
begin
SET @retVal = (Select count (ProductID) from CurrentProduction where Reason = 'BROKEN_SHELL');
end
else 
begin
SET @retVal = (Select count (ProductID) from CurrentProduction where Reason = 'BROKEN_SHELL' AND ProductID = @ProdID);
end
RETURN @retVal;
END


GO
Create Procedure howManyBrokenAxel
@ProdID INT
AS
BEGIN
DECLARE @retVal INT;
if (@ProdID = 0)
begin
SET @retVal = (Select count (ProductID) from CurrentProduction where Reason = 'BROKEN_AXLE');
end
else
begin
SET @retVal = (Select count (ProductID) from CurrentProduction where Reason = 'BROKEN_AXLE' AND ProductID = @ProdID);
end
RETURN @retVal;
END




GO
Create Procedure howManyTangledString
@ProdID INT
AS
BEGIN
DECLARE @retVal INT;
if (@ProdID = 0)
begin
SET @retVal = (Select count (ProductID) from CurrentProduction where Reason = 'TANGLED_STRING');
end
else
begin
SET @retVal = (Select count (ProductID) from CurrentProduction where Reason = 'TANGLED_STRING' AND ProductID = @ProdID);
end
RETURN @retVal;
END




GO
Create Procedure howManyPrimerDefect
@ProdID INT
AS
BEGIN
DECLARE @retVal INT;
if (@ProdID = 0)
begin
SET @retVal = (Select count (ProductID) from CurrentProduction where Reason = 'PRIMER_DEFECT');
end
else
begin
SET @retVal = (Select count (ProductID) from CurrentProduction where Reason = 'PRIMER_DEFECT' AND ProductID = @ProdID);
end
RETURN @retVal;
END



GO
Create Procedure howManyDripMark
@ProdID INT
AS
BEGIN
DECLARE @retVal INT;
if (@ProdID = 0)
begin
SET @retVal = (Select count (ProductID) from CurrentProduction where Reason = 'DRIP_MARK');
end
else
begin
SET @retVal = (Select count (ProductID) from CurrentProduction where Reason = 'DRIP_MARK' AND ProductID = @ProdID);
end
RETURN @retVal;
END




GO
Create Procedure howInconsistentThickness
@ProdID INT
AS
BEGIN
DECLARE @retVal INT;
if (@ProdID = 0)
begin
SET @retVal = (Select count (ProductID) from CurrentProduction where Reason = 'INCONSISTENT_THICKNESS');
end
else
begin
SET @retVal = (Select count (ProductID) from CurrentProduction where Reason = 'INCONSISTENT_THICKNESS' AND ProductID = @ProdID);
end
RETURN @retVal;
END





GO
Create Procedure howManyWarping
@ProdID INT
AS
BEGIN
DECLARE @retVal INT;
if (@ProdID = 0)
begin
SET @retVal = (Select count (ProductID) from CurrentProduction where Reason = 'WARPING');
end
else
begin
SET @retVal = (Select count (ProductID) from CurrentProduction where Reason = 'WARPING' AND ProductID = @ProdID);
end
RETURN @retVal;
END





GO
Create Procedure howManyPitting
@ProdID INT
AS
BEGIN
DECLARE @retVal INT;
if (@ProdID = 0)
begin
SET @retVal = (Select count (ProductID) from CurrentProduction where Reason = 'PITTING');
end
else
begin
SET @retVal = (Select count (ProductID) from CurrentProduction where Reason = 'PITTING' AND ProductID = @ProdID);
end
RETURN @retVal;
END
