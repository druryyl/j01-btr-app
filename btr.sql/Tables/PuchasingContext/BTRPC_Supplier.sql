﻿CREATE TABLE BTRPC_Supplier(
    SupplierId VARCHAR(5) NOT NULL CONSTRAINT DF_BTRPC_Supplier_SupplierId DEFAULT(''),
    SupplierName VARCHAR(50) NOT NULL CONSTRAINT DF_BTRPC_Supplier_SupplierName DEFAULT(''),

    CONSTRAINT PK_BTRPC_Supplier_SupplierId PRIMARY KEY CLUSTERED(SupplierId)
)
GO