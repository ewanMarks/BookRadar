CREATE TABLE dbo.HistorialBusquedas
(
    Id BIGINT IDENTITY(1,1) PRIMARY KEY,
    Autor NVARCHAR(200) NOT NULL,
    Titulo NVARCHAR(400) NOT NULL,
    AnioPublicacion INT NULL,
    Editorial NVARCHAR(200) NULL,
    FechaConsulta DATETIME2(0) NOT NULL
);

CREATE INDEX IX_HistorialBusquedas_Autor_Titulo_Fecha
    ON dbo.HistorialBusquedas (Autor, Titulo, FechaConsulta DESC);