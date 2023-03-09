# Detail System BTR-APP

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
