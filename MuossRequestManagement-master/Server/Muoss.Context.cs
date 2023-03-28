using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RequestManagement.Shared.Models;

namespace RequestManagement.Server;

public partial class MuossContext : DbContext
{
    public MuossContext()
    {
    }

    public MuossContext(DbContextOptions<MuossContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MasService> MasServices { get; set; }

    public virtual DbSet<TabAttachmentType> TabAttachmentTypes { get; set; }

    public virtual DbSet<TabCardReason> TabCardReasons { get; set; }

    public virtual DbSet<TabDocumentType> TabDocumentTypes { get; set; }

    public virtual DbSet<TabItemStatus> TabItemStatuses { get; set; }

    public virtual DbSet<TabReceiveType> TabReceiveTypes { get; set; }

    public virtual DbSet<TabRequestStatus> TabRequestStatuses { get; set; }

    public virtual DbSet<TabServiceGroup> TabServiceGroups { get; set; }

    public virtual DbSet<TabTitle> TabTitles { get; set; }

    public virtual DbSet<TrChangeName> TrChangeNames { get; set; }

    public virtual DbSet<TrRequest> TrRequests { get; set; }

    public virtual DbSet<TrRequestAddress> TrRequestAddresses { get; set; }

    public virtual DbSet<TrRequestAttachment> TrRequestAttachments { get; set; }

    public virtual DbSet<TrRequestFee> TrRequestFees { get; set; }

    public virtual DbSet<TrRequestItem> TrRequestItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        string connectionString = configuration.GetConnectionString("DefaultConnection")!;
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Thai_CI_AS");

        modelBuilder.Entity<MasService>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK_mas_service");

            entity.ToTable("MasService");

            entity.Property(e => e.ServiceId)
                .ValueGeneratedNever()
                .HasColumnName("ServiceID");
            entity.Property(e => e.ActiveStatus).HasMaxLength(1);
            entity.Property(e => e.DocLang).HasMaxLength(2);
            entity.Property(e => e.DocType).HasMaxLength(2);
            entity.Property(e => e.FeeRate).HasColumnType("money");
            entity.Property(e => e.ForStatus).HasMaxLength(1);
            entity.Property(e => e.LastUpdate).HasColumnType("datetime");
            entity.Property(e => e.ServiceEnname)
                .HasMaxLength(200)
                .HasColumnName("ServiceENName");
            entity.Property(e => e.ServiceGroup).HasMaxLength(1);
            entity.Property(e => e.ServiceThname)
                .HasMaxLength(200)
                .HasColumnName("ServiceTHName");
            entity.Property(e => e.UpdateBy).HasMaxLength(50);

            entity.HasOne(d => d.DocTypeNavigation).WithMany(p => p.MasServices)
                .HasForeignKey(d => d.DocType)
                .HasConstraintName("FK__MasServic__DocTy__6EC0713C");

            entity.HasOne(d => d.ServiceGroupNavigation).WithMany(p => p.MasServices)
                .HasForeignKey(d => d.ServiceGroup)
                .HasConstraintName("FK__mas_servi__Servi__57DD0BE4");
        });

        modelBuilder.Entity<TabAttachmentType>(entity =>
        {
            entity.HasKey(e => e.AttachType).HasName("PK_tab_Attachment_Type");

            entity.ToTable("TabAttachmentType");

            entity.Property(e => e.AttachTypeEnname)
                .HasMaxLength(50)
                .HasColumnName("AttachTypeENName");
            entity.Property(e => e.AttachTypeThname)
                .HasMaxLength(50)
                .HasColumnName("AttachTypeTHName");
        });

        modelBuilder.Entity<TabCardReason>(entity =>
        {
            entity.HasKey(e => e.CardCode).HasName("PK_tab_Card_Reason");

            entity.ToTable("TabCardReason");

            entity.Property(e => e.Enreason)
                .HasMaxLength(50)
                .HasColumnName("ENReason");
            entity.Property(e => e.Threason)
                .HasMaxLength(50)
                .HasColumnName("THReason");
        });

        modelBuilder.Entity<TabDocumentType>(entity =>
        {
            entity.HasKey(e => e.DocType);

            entity.ToTable("TabDocumentType");

            entity.Property(e => e.DocType).HasMaxLength(2);
            entity.Property(e => e.DocEntype)
                .HasMaxLength(50)
                .HasColumnName("DocENType");
            entity.Property(e => e.DocThtype)
                .HasMaxLength(50)
                .HasColumnName("DocTHType");
        });

        modelBuilder.Entity<TabItemStatus>(entity =>
        {
            entity.HasKey(e => e.ItemSts).HasName("PK_tab_item_status");

            entity.ToTable("TabItemStatus");

            entity.Property(e => e.ItemSts).HasMaxLength(2);
            entity.Property(e => e.ItemEnstatus)
                .HasMaxLength(50)
                .HasColumnName("ItemENStatus");
            entity.Property(e => e.ItemThstatus)
                .HasMaxLength(50)
                .HasColumnName("ItemTHStatus");
        });

        modelBuilder.Entity<TabReceiveType>(entity =>
        {
            entity.HasKey(e => e.ReceiveType).HasName("PK_tab_Receive_type");

            entity.ToTable("TabReceiveType");

            entity.Property(e => e.ReceiveEndescription)
                .HasMaxLength(50)
                .HasColumnName("ReceiveENDescription");
            entity.Property(e => e.ReceiveThdescription)
                .HasMaxLength(50)
                .HasColumnName("ReceiveTHDescription");
        });

        modelBuilder.Entity<TabRequestStatus>(entity =>
        {
            entity.HasKey(e => e.RequestStatus).HasName("PK_tab_Request_Status");

            entity.ToTable("TabRequestStatus");

            entity.Property(e => e.RequestStatus).HasMaxLength(2);
            entity.Property(e => e.RequestEnstatus)
                .HasMaxLength(50)
                .HasColumnName("RequestENstatus");
            entity.Property(e => e.RequestThstatus)
                .HasMaxLength(50)
                .HasColumnName("RequestTHstatus");
        });

        modelBuilder.Entity<TabServiceGroup>(entity =>
        {
            entity.HasKey(e => e.ServiceGroup).HasName("PK_tab_service_group");

            entity.ToTable("TabServiceGroup");

            entity.Property(e => e.ServiceGroup).HasMaxLength(1);
            entity.Property(e => e.ServiceEngroupName)
                .HasMaxLength(50)
                .HasColumnName("ServiceENGroupName");
            entity.Property(e => e.ServiceThgroupName)
                .HasMaxLength(50)
                .HasColumnName("ServiceTHGroupName");
        });

        modelBuilder.Entity<TabTitle>(entity =>
        {
            entity.HasKey(e => e.TitleCode).HasName("PK_tab_Title");

            entity.ToTable("TabTitle");

            entity.Property(e => e.TitleCode).HasMaxLength(5);
            entity.Property(e => e.Entitle)
                .HasMaxLength(50)
                .HasColumnName("ENTitle");
            entity.Property(e => e.Thtitle)
                .HasMaxLength(50)
                .HasColumnName("THTitle");
        });

        modelBuilder.Entity<TrChangeName>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK_tr_change_name");

            entity.ToTable("TrChangeName");

            entity.Property(e => e.RequestId)
                .ValueGeneratedNever()
                .HasColumnName("RequestID");
            entity.Property(e => e.Efname)
                .HasMaxLength(50)
                .HasColumnName("EFname");
            entity.Property(e => e.Elname)
                .HasMaxLength(50)
                .HasColumnName("ELname");
            entity.Property(e => e.Tfname)
                .HasMaxLength(50)
                .HasColumnName("TFname");
            entity.Property(e => e.TitleCode).HasMaxLength(5);
            entity.Property(e => e.Tlname)
                .HasMaxLength(50)
                .HasColumnName("TLname");

            entity.HasOne(d => d.Request).WithOne(p => p.TrChangeName)
                .HasForeignKey<TrChangeName>(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tr_change__reque__55F4C372");

            entity.HasOne(d => d.TitleCodeNavigation).WithMany(p => p.TrChangeNames)
                .HasForeignKey(d => d.TitleCode)
                .HasConstraintName("FK__tr_change__Title__56E8E7AB");
        });

        modelBuilder.Entity<TrRequest>(entity =>
        {
            entity.HasKey(e => e.RequestID).HasName("PK_tr_request");

            entity.ToTable("TrRequest");

            entity.Property(e => e.RequestID).HasColumnName("RequestID");
            entity.Property(e => e.CancelDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.PaidDate).HasColumnType("datetime");
            entity.Property(e => e.PaidStatus).HasMaxLength(1);
            entity.Property(e => e.Phone).HasMaxLength(10);
            entity.Property(e => e.ReceiptLink).HasMaxLength(200);
            entity.Property(e => e.ReceiptNum).HasMaxLength(10);
            entity.Property(e => e.ReceiveDate).HasColumnType("datetime");
            entity.Property(e => e.Ref1).HasMaxLength(50);
            entity.Property(e => e.Ref2).HasMaxLength(50);
            entity.Property(e => e.RequestDate).HasColumnType("datetime");
            entity.Property(e => e.RequestStatus).HasMaxLength(2);
            entity.Property(e => e.RequesterID)
                .HasMaxLength(7)
                .HasColumnName("RequesterID");
            entity.Property(e => e.SendDate).HasColumnType("date");
            entity.Property(e => e.TotalPrice).HasColumnType("money");
            entity.Property(e => e.TrackNo).HasMaxLength(30);

            entity.HasOne(d => d.ReceiveTypeNavigation).WithMany(p => p.TrRequests)
                .HasForeignKey(d => d.ReceiveType)
                .HasConstraintName("FK__tr_reques__recei__4B7734FF");

            entity.HasOne(d => d.RequestStatusNavigation).WithMany(p => p.TrRequests)
                .HasForeignKey(d => d.RequestStatus)
                .HasConstraintName("FK__tr_reques__reque__4A8310C6");
        });

        modelBuilder.Entity<TrRequestAddress>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK_tr_request_address");

            entity.ToTable("TrRequestAddress");

            entity.Property(e => e.RequestId)
                .ValueGeneratedNever()
                .HasColumnName("RequestID");
            entity.Property(e => e.AddrNo).HasMaxLength(500);
            entity.Property(e => e.AddrType).HasMaxLength(1);
            entity.Property(e => e.AmphoeIdn)
                .HasMaxLength(4)
                .HasColumnName("AmphoeIDN");
            entity.Property(e => e.ProvCode).HasMaxLength(2);
            entity.Property(e => e.TambonIdn)
                .HasMaxLength(6)
                .HasColumnName("TambonIDN");
            entity.Property(e => e.Zipcode).HasMaxLength(5);

            entity.HasOne(d => d.Request).WithOne(p => p.TrRequestAddress)
                .HasForeignKey<TrRequestAddress>(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tr_reques__reque__531856C7");
        });

        modelBuilder.Entity<TrRequestAttachment>(entity =>
        {
            entity.HasKey(e => e.AttachId).HasName("PK_tr_request_attachment");

            entity.ToTable("TrRequestAttachment");

            entity.Property(e => e.AttachId).HasColumnName("AttachID");
            entity.Property(e => e.AttachFile).HasMaxLength(100);
            entity.Property(e => e.RequestId).HasColumnName("RequestID");

            entity.HasOne(d => d.AttachTypeNavigation).WithMany(p => p.TrRequestAttachments)
                .HasForeignKey(d => d.AttachType)
                .HasConstraintName("FK__TrRequest__Attac__6DCC4D03");

            entity.HasOne(d => d.Request).WithMany(p => p.TrRequestAttachments)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("FK__tr_reques__reque__540C7B00");
        });

        modelBuilder.Entity<TrRequestFee>(entity =>
        {
            entity.HasKey(e => e.TranFeeId).HasName("PK_tr_request_fee");

            entity.ToTable("TrRequestFee");

            entity.Property(e => e.TranFeeId).HasColumnName("TranFeeID");
            entity.Property(e => e.FeeAmount)
                .HasComputedColumnSql("(isnull([NoOfCopy],(0))*isnull([FeeRate],(0)))", false)
                .HasColumnType("money");
            entity.Property(e => e.FeeRate).HasColumnType("money");
            entity.Property(e => e.RequestId).HasColumnName("RequestID");

            entity.HasOne(d => d.FeeTypeNavigation).WithMany(p => p.TrRequestFees)
                .HasForeignKey(d => d.FeeType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tr_reques__fee_t__5224328E");

            entity.HasOne(d => d.Request).WithMany(p => p.TrRequestFees)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tr_reques__reque__503BEA1C");
        });

        modelBuilder.Entity<TrRequestItem>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK_tr_request_item");

            entity.ToTable("TrRequestItem");

            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.CardCodeText).HasMaxLength(50);
            entity.Property(e => e.DocExpired).HasColumnType("date");
            entity.Property(e => e.DocFormat).HasMaxLength(1);
            entity.Property(e => e.GenerateBy).HasMaxLength(50);
            entity.Property(e => e.GenerateDate).HasColumnType("datetime");
            entity.Property(e => e.ItemSts).HasMaxLength(2);
            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

            entity.HasOne(d => d.CardCodeNavigation).WithMany(p => p.TrRequestItems)
                .HasForeignKey(d => d.CardCode)
                .HasConstraintName("FK__tr_reques__CardC__4F47C5E3");

            entity.HasOne(d => d.ItemStsNavigation).WithMany(p => p.TrRequestItems)
                .HasForeignKey(d => d.ItemSts)
                .HasConstraintName("FK__tr_reques__item___4E53A1AA");

            entity.HasOne(d => d.Request).WithMany(p => p.TrRequestItems)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tr_reques__reque__4C6B5938");

            entity.HasOne(d => d.Service).WithMany(p => p.TrRequestItems)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK__tr_reques__Servi__4D5F7D71");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
