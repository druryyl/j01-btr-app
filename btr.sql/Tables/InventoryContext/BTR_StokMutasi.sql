﻿CREATE TABLE BTR_StokMutasi(
    StokId VARCHAR(13) NOT NULL CONSTRAINT DF_BTR_StokMutasi_StokId DEFAULT(''),
    StokMutasiId VARCHAR(17) NOT NULL CONSTRAINT DF_BTR_StokMutasi_StokMutasiId DEFAULT(''),
    MutasiId VARCHAR(13) NOT NULL CONSTRAINT DF_BTR_StokMutasi_MutasiId DEFAULT(''),
    NoUrut INT NOT NULL CONSTRAINT DF_BTR_StokMutasi_NoUrut DEFAULT(0),
    MutasiDate DATETIME NOT NULL CONSTRAINT DF_BTR_StokMutasi_MutasiDate DEFAULT('3000-01-01'),
    QtyIn INT NOT NULL CONSTRAINT DF_BTR_StokMutasi_QtyIn DEFAULT(0),
    QtyOut INT NOT NULL CONSTRAINT DF_BTR_StokMutasi_QtyOut DEFAULT(0),
    HargaJual DECIMAL(18,2) NOT NULL CONSTRAINT DF_BTR_StokMutasi_HargaJual DEFAULT(0),
    
    CONSTRAINT PK_BTR_StokMutasi PRIMARY KEY CLUSTERED (StokMutasiId)
)
GO

CREATE INDEX IX_BTR_StokMutasi_StokId
    ON BTR_StokMutasi (StokId, StokMutasiId)
    WITH(FILLFACTOR=95)
GO
