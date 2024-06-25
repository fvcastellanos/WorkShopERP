
using Microsoft.EntityFrameworkCore;

namespace WorkShopERP.Model 
{

    public class WorkShopERPContext : DbContext
    {

        public virtual DbSet<CarBrand> CarBrands { get; set; } = null!;
        public virtual DbSet<CarLine> CarLines { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<DiscountType> DiscountTypes { get; set; } = null!;
        public virtual DbSet<FlywaySchemaHistory> FlywaySchemaHistories { get; set; } = null!;
        public virtual DbSet<Inventory> Inventories { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; } = null!;
        public virtual DbSet<OperationType> OperationTypes { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public virtual DbSet<Sequence> Sequences { get; set; } = null!;
        public virtual DbSet<Tenant> Tenants { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<WorkOrder> WorkOrders { get; set; } = null!;
        public virtual DbSet<WorkOrderDetail> WorkOrderDetails { get; set; } = null!;


        public WorkShopERPContext(DbContextOptions options): base(options)
        {
            // db context initialize
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarBrand>(entity =>
            {
                entity.ToTable("car_brand");

                entity.HasIndex(e => e.Active, "idx_car_brand_active");

                entity.HasIndex(e => e.Created, "idx_car_brand_created");

                entity.HasIndex(e => new { e.Name, e.Tenant }, "idx_car_brand_name")
                    .IsUnique();

                entity.HasIndex(e => e.Tenant, "idx_car_brand_tenant");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Created)
                    .HasColumnType("timestamp")
                    .HasColumnName("created")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Tenant)
                    .HasMaxLength(50)
                    .HasColumnName("tenant");
            });

            modelBuilder.Entity<CarLine>(entity =>
            {
                entity.ToTable("car_line");

                entity.HasIndex(e => e.CarBrandId, "fk_car_line_car_brand1_idx");

                entity.HasIndex(e => e.Active, "idx_car_line_active");

                entity.HasIndex(e => e.Created, "idx_car_line_created");

                entity.HasIndex(e => new { e.Name, e.Tenant }, "idx_car_line_name")
                    .IsUnique();

                entity.HasIndex(e => e.Tenant, "idx_car_line_tenant");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CarBrandId)
                    .HasMaxLength(50)
                    .HasColumnName("car_brand_id");

                entity.Property(e => e.Created)
                    .HasColumnType("timestamp")
                    .HasColumnName("created")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Tenant)
                    .HasMaxLength(50)
                    .HasColumnName("tenant");

                entity.HasOne(d => d.CarBrand)
                    .WithMany(p => p.CarLines)
                    .HasForeignKey(d => d.CarBrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_car_line_car_brand1");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("contact");

                entity.HasIndex(e => e.Active, "idx_contact_active");

                entity.HasIndex(e => e.Created, "idx_contact_created");

                entity.HasIndex(e => e.Name, "idx_contact_name");

                entity.HasIndex(e => e.TaxId, "idx_contact_tax_id");

                entity.HasIndex(e => e.Tenant, "idx_contact_tenant");

                entity.HasIndex(e => e.Updated, "idx_contact_updated");

                entity.HasIndex(e => e.Type, "idx_contat_type");

                entity.HasIndex(e => new { e.Code, e.Tenant }, "uq_contact_code")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .HasColumnName("code");

                entity.Property(e => e.Contact1)
                    .HasMaxLength(150)
                    .HasColumnName("contact");

                entity.Property(e => e.Created)
                    .HasColumnType("timestamp")
                    .HasColumnName("created")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .HasColumnName("name");

                entity.Property(e => e.TaxId)
                    .HasMaxLength(50)
                    .HasColumnName("tax_id");

                entity.Property(e => e.Tenant)
                    .HasMaxLength(50)
                    .HasColumnName("tenant");

                entity.Property(e => e.Type)
                    .HasMaxLength(1)
                    .HasColumnName("type")
                    .HasDefaultValueSql("'C'")
                    .IsFixedLength();

                entity.Property(e => e.Updated)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<DiscountType>(entity =>
            {
                entity.ToTable("discount_type");

                entity.HasIndex(e => e.Active, "idx_discount_type_active");

                entity.HasIndex(e => e.Created, "idx_discount_type_created");

                entity.HasIndex(e => e.Tenant, "idx_discount_type_tenantId");

                entity.HasIndex(e => e.Updated, "idx_discount_type_updated");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Created)
                    .HasColumnType("timestamp")
                    .HasColumnName("created")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .HasColumnName("name");

                entity.Property(e => e.Tenant)
                    .HasMaxLength(50)
                    .HasColumnName("tenant");

                entity.Property(e => e.Updated)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<FlywaySchemaHistory>(entity =>
            {
                entity.HasKey(e => e.InstalledRank)
                    .HasName("PRIMARY");

                entity.ToTable("flyway_schema_history");

                entity.HasIndex(e => e.Success, "flyway_schema_history_s_idx");

                entity.Property(e => e.InstalledRank).HasColumnName("installed_rank");

                entity.Property(e => e.Checksum).HasColumnName("checksum");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .HasColumnName("description");

                entity.Property(e => e.ExecutionTime).HasColumnName("execution_time");

                entity.Property(e => e.InstalledBy)
                    .HasMaxLength(100)
                    .HasColumnName("installed_by");

                entity.Property(e => e.InstalledOn)
                    .HasColumnType("timestamp")
                    .HasColumnName("installed_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Script)
                    .HasMaxLength(1000)
                    .HasColumnName("script");

                entity.Property(e => e.Success).HasColumnName("success");

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .HasColumnName("type");

                entity.Property(e => e.Version)
                    .HasMaxLength(50)
                    .HasColumnName("version");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("inventory");

                entity.HasIndex(e => e.InvoiceDetailId, "fk_inventory_invoice_detail1_idx");

                entity.HasIndex(e => e.ProductId, "fk_inventory_product1_idx");

                entity.HasIndex(e => e.Created, "idx_inventory_created");

                entity.HasIndex(e => e.OperationDate, "idx_inventory_operation_date");

                entity.HasIndex(e => e.OperationType, "idx_inventory_operation_type");

                entity.HasIndex(e => e.Tenant, "idx_inventory_tenant_id");

                entity.HasIndex(e => e.Updated, "idx_inventory_updated");

                entity.HasIndex(e => new { e.ProductId, e.InvoiceDetailId, e.OperationType, e.Tenant }, "uq_inventory_movement_tenant")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("id");

                entity.Property(e => e.Created)
                    .HasColumnType("timestamp")
                    .HasColumnName("created")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .HasColumnName("description");

                entity.Property(e => e.DiscountAmount).HasColumnName("discount_amount");

                entity.Property(e => e.InvoiceDetailId)
                    .HasMaxLength(50)
                    .HasColumnName("invoice_detail_id");

                entity.Property(e => e.OperationDate)
                    .HasColumnType("timestamp")
                    .HasColumnName("operation_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.OperationType)
                    .HasMaxLength(1)
                    .HasColumnName("operation_type")
                    .IsFixedLength();

                entity.Property(e => e.ProductId)
                    .HasMaxLength(50)
                    .HasColumnName("product_id");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Tenant)
                    .HasMaxLength(50)
                    .HasColumnName("tenant");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.UnitPrice).HasColumnName("unit_price");

                entity.Property(e => e.Updated)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.InvoiceDetail)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.InvoiceDetailId)
                    .HasConstraintName("fk_inventory_invoice_detail1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_inventory_product1");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("invoice");

                entity.HasIndex(e => e.ContactId, "fk_provider_invoice_contact1_idx");

                entity.HasIndex(e => e.Created, "idx_invoice_created");

                entity.HasIndex(e => e.InvoiceDate, "idx_invoice_date");

                entity.HasIndex(e => e.EffectiveDate, "idx_invoice_effective_date");

                entity.HasIndex(e => e.Status, "idx_invoice_status");

                entity.HasIndex(e => e.Tenant, "idx_invoice_tenant");

                entity.HasIndex(e => e.Type, "idx_invoice_type");

                entity.HasIndex(e => e.Updated, "idx_invoice_updated");

                entity.HasIndex(e => new { e.Suffix, e.Number, e.Tenant, e.Type, e.ContactId }, "uq_invoice_number")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("id");

                entity.Property(e => e.ContactId)
                    .HasMaxLength(50)
                    .HasColumnName("contact_id");

                entity.Property(e => e.Created)
                    .HasColumnType("timestamp")
                    .HasColumnName("created")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.EffectiveDate)
                    .HasColumnType("timestamp")
                    .HasColumnName("effective_date");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(250)
                    .HasColumnName("image_url");

                entity.Property(e => e.InvoiceDate)
                    .HasColumnType("timestamp")
                    .HasColumnName("invoice_date");

                entity.Property(e => e.Number)
                    .HasMaxLength(100)
                    .HasColumnName("number");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'A'")
                    .IsFixedLength();

                entity.Property(e => e.Suffix)
                    .HasMaxLength(30)
                    .HasColumnName("suffix");

                entity.Property(e => e.Tenant)
                    .HasMaxLength(50)
                    .HasColumnName("tenant");

                entity.Property(e => e.Type)
                    .HasMaxLength(45)
                    .HasColumnName("type")
                    .HasDefaultValueSql("'P'");

                entity.Property(e => e.Updated)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_provider_invoice_contact1");
            });

            modelBuilder.Entity<InvoiceDetail>(entity =>
            {
                entity.ToTable("invoice_detail");

                entity.HasIndex(e => e.InvoiceId, "fk_invoice_detail_invoice1_idx");

                entity.HasIndex(e => e.ProductId, "fk_invoice_detail_product1_idx");

                entity.HasIndex(e => e.WorkOrderId, "fk_invoice_detail_work_order1_idx");

                entity.HasIndex(e => new { e.InvoiceId, e.ProductId, e.Tenant }, "uq_invoice_detail_detail")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("id");

                entity.Property(e => e.Created)
                    .HasColumnType("timestamp")
                    .HasColumnName("created")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DiscountAmount).HasColumnName("discount_amount");

                entity.Property(e => e.InvoiceId)
                    .HasMaxLength(50)
                    .HasColumnName("invoice_id");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(50)
                    .HasColumnName("product_id");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Tenant)
                    .HasMaxLength(50)
                    .HasColumnName("tenant");

                entity.Property(e => e.UnitPrice).HasColumnName("unit_price");

                entity.Property(e => e.WorkOrderId)
                    .HasMaxLength(50)
                    .HasColumnName("work_order_id");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.InvoiceDetails)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_invoice_detail_invoice1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.InvoiceDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_invoice_detail_product1");

                entity.HasOne(d => d.WorkOrder)
                    .WithMany(p => p.InvoiceDetails)
                    .HasForeignKey(d => d.WorkOrderId)
                    .HasConstraintName("fk_invoice_detail_work_order1");
            });

            modelBuilder.Entity<OperationType>(entity =>
            {
                entity.ToTable("operation_type");

                entity.HasIndex(e => e.Active, "idx_operation_type_active");

                entity.HasIndex(e => e.Created, "idx_operation_type_created");

                entity.HasIndex(e => e.Tenant, "idx_operation_type_tenant_id");

                entity.HasIndex(e => e.Type, "idx_operation_type_type");

                entity.HasIndex(e => e.Updated, "idx_operation_type_updated");

                entity.HasIndex(e => e.Code, "operation_type_code_IDX");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .HasColumnName("code");

                entity.Property(e => e.Created)
                    .HasColumnType("timestamp")
                    .HasColumnName("created")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .HasColumnName("name");

                entity.Property(e => e.Tenant)
                    .HasMaxLength(50)
                    .HasColumnName("tenant");

                entity.Property(e => e.Type)
                    .HasMaxLength(1)
                    .HasColumnName("type")
                    .HasDefaultValueSql("'I'")
                    .IsFixedLength();

                entity.Property(e => e.Updated)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.HasIndex(e => e.Active, "idx_product_active");

                entity.HasIndex(e => e.Created, "idx_product_created");

                entity.HasIndex(e => e.Tenant, "idx_product_tenant");

                entity.HasIndex(e => e.Type, "idx_product_type");

                entity.HasIndex(e => e.Updated, "idx_product_updated");

                entity.HasIndex(e => e.ProductCategoryId, "product_product_category_id_FK");

                entity.HasIndex(e => new { e.Code, e.Tenant }, "uq_product_code")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .HasColumnName("code");

                entity.Property(e => e.Created)
                    .HasColumnType("timestamp")
                    .HasColumnName("created")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .HasColumnName("description");

                entity.Property(e => e.MinimalQuantity).HasColumnName("minimal_quantity");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .HasColumnName("name");

                entity.Property(e => e.ProductCategoryId)
                    .HasMaxLength(50)
                    .HasColumnName("product_category_id");

                entity.Property(e => e.SalePrice).HasColumnName("sale_price");

                entity.Property(e => e.Tenant)
                    .HasMaxLength(50)
                    .HasColumnName("tenant");

                entity.Property(e => e.Type)
                    .HasMaxLength(1)
                    .HasColumnName("type")
                    .HasDefaultValueSql("'P'")
                    .IsFixedLength();

                entity.Property(e => e.Updated)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductCategoryId)
                    .HasConstraintName("product_product_category_id_FK");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("product_category");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .HasColumnName("code");

                entity.Property(e => e.Created)
                    .HasColumnType("timestamp")
                    .HasColumnName("created")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .HasColumnName("name");

                entity.Property(e => e.Tenant)
                    .HasMaxLength(50)
                    .HasColumnName("tenant");

                entity.Property(e => e.Updated)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Sequence>(entity =>
            {
                entity.ToTable("sequence");

                entity.HasIndex(e => e.Prefix, "uq_sequence_prefix")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Prefix)
                    .HasMaxLength(5)
                    .HasColumnName("prefix");

                entity.Property(e => e.Updated)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Value)
                    .HasMaxLength(30)
                    .HasColumnName("value");
            });

            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.ToTable("tenant");

                entity.HasIndex(e => e.Code, "idx_tenant_code");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .HasColumnName("code");

                entity.Property(e => e.Created)
                    .HasColumnType("timestamp")
                    .HasColumnName("created")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .HasColumnName("name");

                entity.Property(e => e.Updated)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.TenantId, "fk_user_tenant1_idx");

                entity.HasIndex(e => new { e.UserId, e.Provider }, "uq_user_user_id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Created)
                    .HasColumnType("timestamp")
                    .HasColumnName("created")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Provider)
                    .HasMaxLength(50)
                    .HasColumnName("provider");

                entity.Property(e => e.TenantId)
                    .HasMaxLength(50)
                    .HasColumnName("tenant_id");

                entity.Property(e => e.Updated)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated");

                entity.Property(e => e.UserId)
                    .HasMaxLength(150)
                    .HasColumnName("user_id");

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_tenant1");
            });

            modelBuilder.Entity<WorkOrder>(entity =>
            {
                entity.ToTable("work_order");

                entity.HasIndex(e => e.CarLineId, "fk_work_order_car_line1_idx");

                entity.HasIndex(e => e.ContactId, "fk_work_order_contact1_idx");

                entity.HasIndex(e => e.PlateNumber, "idx_work_order_plate_number");

                entity.HasIndex(e => new { e.Number, e.Tenant }, "uq_work_order_number")
                    .IsUnique();

                entity.HasIndex(e => e.OrderDate, "work_order_order_date_IDX");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("id");

                entity.Property(e => e.CarLineId)
                    .HasMaxLength(50)
                    .HasColumnName("car_line_id");

                entity.Property(e => e.ContactId)
                    .HasMaxLength(50)
                    .HasColumnName("contact_id");

                entity.Property(e => e.Created)
                    .HasColumnType("timestamp")
                    .HasColumnName("created")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.GasAmount).HasColumnName("gas_amount");

                entity.Property(e => e.Notes)
                    .HasColumnType("text")
                    .HasColumnName("notes");

                entity.Property(e => e.Number)
                    .HasMaxLength(100)
                    .HasColumnName("number");

                entity.Property(e => e.OdometerMeasurement)
                    .HasMaxLength(1)
                    .HasColumnName("odometer_measurement")
                    .HasDefaultValueSql("'K'")
                    .IsFixedLength();

                entity.Property(e => e.OdometerValue).HasColumnName("odometer_value");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("timestamp")
                    .HasColumnName("order_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.PlateNumber)
                    .HasMaxLength(30)
                    .HasColumnName("plate_number");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'P'")
                    .IsFixedLength();

                entity.Property(e => e.Tenant)
                    .HasMaxLength(50)
                    .HasColumnName("tenant");

                entity.Property(e => e.Updated)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.CarLine)
                    .WithMany(p => p.WorkOrders)
                    .HasForeignKey(d => d.CarLineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_work_order_car_line1");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.WorkOrders)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_work_order_contact1");
            });

            modelBuilder.Entity<WorkOrderDetail>(entity =>
            {
                entity.ToTable("work_order_detail");

                entity.HasIndex(e => e.InvoiceDetailId, "fk_work_order_detail_invoice_detail1_idx");

                entity.HasIndex(e => e.ProductId, "fk_work_order_detail_product1_idx");

                entity.HasIndex(e => e.WorkOrderId, "fk_work_order_detail_work_order1_idx");

                entity.HasIndex(e => e.Tenant, "idx_work_order_detail_tenant");

                entity.HasIndex(e => new { e.WorkOrderId, e.ProductId, e.Tenant }, "uq_work_order_detail_details")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("id");

                entity.Property(e => e.Created)
                    .HasColumnType("timestamp")
                    .HasColumnName("created")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.InvoiceDetailId)
                    .HasMaxLength(50)
                    .HasColumnName("invoice_detail_id");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(50)
                    .HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Tenant)
                    .HasMaxLength(50)
                    .HasColumnName("tenant");

                entity.Property(e => e.UnitPrice).HasColumnName("unit_price");

                entity.Property(e => e.WorkOrderId)
                    .HasMaxLength(50)
                    .HasColumnName("work_order_id");

                entity.HasOne(d => d.InvoiceDetail)
                    .WithMany(p => p.WorkOrderDetails)
                    .HasForeignKey(d => d.InvoiceDetailId)
                    .HasConstraintName("fk_work_order_detail_invoice_detail1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.WorkOrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_work_order_detail_product1");

                entity.HasOne(d => d.WorkOrder)
                    .WithMany(p => p.WorkOrderDetails)
                    .HasForeignKey(d => d.WorkOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_work_order_detail_work_order1");
            });

            // OnModelCreatingPartial(modelBuilder);
        }

        // partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
