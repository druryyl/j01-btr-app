# BTR-APP

## Modeling

1. Pengadaan
    1. SupplierAgg
        1. Supplier
            - SupplierId
            - SupplierName
    2. PurchaseOrderAgg
        1. PurchaseOrder
            - PurchaseOrderId
            - PurchaseDate
            - SupplierId
            - StatusPO
            - (aggregate-signature)
        2. PurchaseOrderItem
            - PurchaseOrderId
            - NoUrut
            - BrgId
            - Satuan
            - Qty
            - Harga
            - DiskonProsen
            - DiskonRupiah
            - TaxProsen
            - TaxRupiah
            - Total
            - QtyReceived
    3. ReceiptAgg
        1. Receipt
            - ReceiptId
            - ReceiptDate
            - SupplierId
            - PurchaseOrderId
            - PegId
            - (aggregate-signature)
        2. ReceiptItem
            - DeliveryOrderId
            - NoUrut
            - BrgId
            - Satuan
            - Qty
    4. FakturAgg
        1. Faktur
            - FakturId
            - FakturDate
            - SupplierId
            - PurchaseOrderId
            - NoFakturPajak
            - NilaiTagihan
            - DiskonProsen
            - DiskonRupiah
            - TaxProsen
            - TaxRupiah
            - (aggregate-signature)
2. Inventory
    1. JenisBrgAgg
        1. JenisBrg
            - JenisBrgId
            - JenisBrgName
            - (aggregate-signature)
    2. BrgAgg
        1. Brg
            - BrgId
            - BrgName
            - (aggregate-signature)
    3. StokAgg
        1. Stok
            - StokId
            - BrgId
            - Satuan
            - (aggregate-signature)
    4. WarehouseAgg
        1. Warehouse
            - WarehouseId
            - WarehouseName
            - (aggregate-signature)
    5. InventoryAgg
        1. Inventory
            - InventoryId
            - InventoryDate
            - WarehouseId
            - ReffId
            - StokId
            - BrgId
            - QtySaldo
        2. InventoryMutasi
            - InventoryId
            - MutasiDate
            - ReffId
            - QtyIn
            - QtyOut
3. Sales
    1. SalesPersonAgg
        1. SalesPerson
            - SalesPersonId
            - SalesPersonName
    2. CustomerAgg
        1. Customer
            - CustomerId
            - CustomerName
            - ContactPerson
            - PhoneNo
            - Address1
            - Address2
            - City
    3. OutletAgg
        1. Outlet
            - OutletId
            - OutletName
            - CustomerId
            - Address1
            - Address2
            - City
    4. DiskonTypeAgg
        1. DiskonType
            - DiskonTypeId
            - DiskonTypeName
    5. SalesOrderAgg
        1. SalesOrder
            - SalesOrderId
            - SalesOrderDate
            - SalesId
            - CustomerId
            - SubTotal
            - Tax
            - GrandTotal
        2. SalesOrderItem
            - SalesOrderId
            - SalesOrderItemId
            - NoUrut
            - StokId
            - BrgId
            - BrgName
            - Qty
            - UnitPrice
            - Discount
            - Total
        3. SalesOrderItemDiskon
            - SalesOrderId
            - SalesOrderItemId
            - NoUrut
            - BasePrice
            - DiskonTypeId
            - DiskonProsen
            - DiskonRupiah
    6. DeliveryOrderAgg
        1. DeliveryOrder
            - DeliveryOrderId
            - DeliveryOrderDate
            - SalesOrderId
            - WarehouseId
            - DriverId
        2. DeliveryOrderItem
            - DeliveryOrderId
            - DeliveryOrderItemId
            - NoUrut
            - StokId
            - BrgId
            - Qty
    7. InvoiceAgg
        1. Invoice
            - InvoiceId
            - InvoiceDate
            - PurchaseOrderId
            - CustomerId
            - DueDate
            - SubTotal
            - Tax
            - GrandTotal
4. Finance
    1. HutangAgg
        1. Hutang
            - HutangId
            - HutangDate
            - SupplierId
            - ReffId
            - DueDate
            - NilaiHutang
            - NilaiLunas
            - SaldoHutang
        2. HutangMutasi
            - HutangId
            - NoUrut
            - MutasiDate
            - LunasHutangId
            - Debit
            - Kredit
    2. LunasHutangAgg
        1. LunasHutang
            - LunasHutangId
            - LunasHutangDate
            - SupplierId
            - TotalLunas
        2. LunasHutangItem
            - LunasHutangId
            - HutangId
            - HutangDate
            - ReffId
            - SaldoHutang
            - NilaiLunas
    3. PiutangAgg
        1. Piutang
            - PiutangId
            - PiutangDate
            - CustomerId
            - ReffId
            - DueDate
            - NilaiPiutang
            - NilaiLunas
            - SaldoPiutang
        2. PiutangMutasi
            - PiutangId
            - NoUrut
            - MutasiDate
            - LunasPiutangId
            - Debit
            - Kredit
    4. LunasPiutangAgg
        1. LunasPiutang
            - LunasPiutangId
            - LunasPiutangDate
            - CustomerId
            - TotalLunas
        2. LunasPiutangItem
            - LunasPiutangId
            - PiutangId
            - PiutangDate
            - ReffId
            - SaldoPiutang
            - NilaiLunas
    5. BukuKasAgg
        1. BukuKas
            - BukuKasId
            - BukuKasTgl
            - SaldoKas
        2. BukuKasMutasi
            - BukuKasId
            - MutasiDate
            - ReffId
            - Debit
            - Kredit
    6. MutasiKasMasukAgg
        1. MutasiKasMasuk
            - MutasiKasMasukId
            - MutasiKasDate
            - Keterangan
            - Nilai
    7. MutasiKasKeluarAgg
        1. MutasiKasKeluar
            - MutasiKasKeluarId
            - MutasiKasDate
            - Keterangan
            - Nilai
    8. BukuTaxAgg
        1. BukuTax
            - BukuTaxId
            - BukuTaxDate
            - SupplierId
            - FakturId
            - CustomerId
            - InvoidId
            - NoFakturPajak
            - NilaiTaxMasuk
            - NilaiTaxKeluar

## Use Case

1. Procurement
    1. Create Purchase Order
    2. Receiving Goods
        1. Update Status PO
        2. Add Stok
    3. Create Faktur
        1. Generate Hutang
    4. Retur Beli
        1. Remove Stok
    5. Close PO
        1. Update Status PO

2. Sales
    1. Create Sales Order
    2. Delivery Order
        1. Update Status SO
        2. Remove Stok
    3. Send Invoice
        1. Generate Piutang
    4. Retur Jual
        1. Add Stok

3. Inventory
    1. Mutasi Stok
        1. Remove Stok Asal
        2. Add Stok Tujuan
    2. Stok Opname
        1. Add Stok
        2. Remove Stok

4. Finance
    1. Mutasi Kas Keluar
        1. Generate Buku Kas
    2. Pelunasan Hutang
        1. Update Buku Hutang
        2. Generate Tax Masukan
    3. Mutasi Kas Masuk
        1. Generate Buku Kas
    4. Pelunasan Piutang
        1. Update Buku Piutang
        2. Generate Tax Keluaran

## Output

1. Procurement
    1. Reporting - PO Per Periode
    2. Reporting - Outstanding PO
    3. KPI - Expenditure Under Management Rate
    4. KPI - Supplier Quality Rate
    5. KPI - Purchase Order Cycle Time
    6. KPI - Lead Time

2. Inventory
    1. Reporting - Buku Stok
    2. Reporting - Nilai Persediaan
    3. Reporting - Forecasting
    4. KPI - Slow Moving
    5. KPI - Death Stock

3. Sales
    1. Reporting - List of Sales
    2. Reporting - Outstanding Sales Order
    3. Reporting - List of Delivery
    4. Reporting - List of Invoice
    5. KPI - Sales Person Performance Indikator
    6. KPI - Sales Volume by Location

4. Finance
    1. Reporting - List Hutang
    2. Reporting - List Pelunasan Hutang
    3. Reporting - List Piutang
    4. Reporting - List Pelunasan Piutang
    5. Reporting - Kas Masuk - Keluar
    6. Reporting - Buku Pajak Masukan-Keluaran
    7. KPI - Umur Hutang-Piutang
