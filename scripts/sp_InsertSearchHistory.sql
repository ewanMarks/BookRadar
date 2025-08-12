CREATE OR ALTER PROCEDURE dbo.sp_InsertSearchHistory
    @Autor NVARCHAR(200),
    @Titulo NVARCHAR(400),
    @AnioPublicacion INT = NULL,
    @Editorial NVARCHAR(200) = NULL,
    @FechaConsulta DATETIME2(0)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (
        SELECT 1
        FROM dbo.HistorialBusquedas
        WHERE Autor = @Autor
          AND Titulo = @Titulo
          AND FechaConsulta >= DATEADD(MINUTE, -1, SYSUTCDATETIME())
    )
    BEGIN
        INSERT INTO dbo.HistorialBusquedas (Autor, Titulo, AnioPublicacion, Editorial, FechaConsulta)
        VALUES (@Autor, @Titulo, @AnioPublicacion, @Editorial, @FechaConsulta);
    END
END
