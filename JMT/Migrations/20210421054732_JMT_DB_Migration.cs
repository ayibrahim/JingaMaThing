using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JMT.Migrations
{
    public partial class JMT_DB_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TCustomerInbox",
                columns: table => new
                {
                    CustomerInboxID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 1073741791, nullable: true),
                    LastName = table.Column<string>(maxLength: 1073741791, nullable: true),
                    ChatMessage = table.Column<string>(maxLength: 1073741791, nullable: false),
                    MessageDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 1073741791, nullable: true),
                    Title = table.Column<string>(maxLength: 1073741791, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TCustomerInbox", x => x.CustomerInboxID);
                });

            migrationBuilder.CreateTable(
                name: "TCustomerPending",
                columns: table => new
                {
                    CustomerPendingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(nullable: false),
                    DeveloperID = table.Column<int>(nullable: false),
                    PriceOffered = table.Column<string>(maxLength: 1073741791, nullable: false),
                    DateOffered = table.Column<DateTime>(nullable: false),
                    OrderDesc = table.Column<string>(maxLength: 1073741791, nullable: false),
                    Requirements = table.Column<string>(maxLength: 1073741791, nullable: false),
                    CPStatus = table.Column<string>(maxLength: 1073741791, nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TCustomerPending", x => x.CustomerPendingID);
                });

            migrationBuilder.CreateTable(
                name: "TCustomers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 1073741791, nullable: false),
                    LastName = table.Column<string>(maxLength: 1073741791, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 1073741791, nullable: false),
                    Email = table.Column<string>(maxLength: 1073741791, nullable: false),
                    Password = table.Column<string>(maxLength: 1073741791, nullable: false),
                    RoleID = table.Column<int>(nullable: false),
                    Photo = table.Column<string>(maxLength: 1073741791, nullable: true),
                    SideBarColor = table.Column<string>(maxLength: 1073741791, nullable: false),
                    DashboardColor = table.Column<string>(maxLength: 1073741791, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TCustomers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "TDeveloperDeclined",
                columns: table => new
                {
                    DeveloperDeclinedID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDescription = table.Column<string>(maxLength: 1073741791, nullable: true),
                    DeclineReason = table.Column<string>(maxLength: 1073741791, nullable: true),
                    DeclinedDate = table.Column<DateTime>(nullable: false),
                    DeveloperPendingID = table.Column<int>(nullable: false),
                    DeveloperID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TDeveloperDeclined", x => x.DeveloperDeclinedID);
                });

            migrationBuilder.CreateTable(
                name: "TDeveloperInbox",
                columns: table => new
                {
                    DeveloperInboxID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeveloperID = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 1073741791, nullable: true),
                    LastName = table.Column<string>(maxLength: 1073741791, nullable: true),
                    ChatMessage = table.Column<string>(maxLength: 1073741791, nullable: true),
                    MessageDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 1073741791, nullable: true),
                    Title = table.Column<string>(maxLength: 1073741791, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TDeveloperInbox", x => x.DeveloperInboxID);
                });

            migrationBuilder.CreateTable(
                name: "TDeveloperLinks",
                columns: table => new
                {
                    DeveloperLinkID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeveloperID = table.Column<int>(nullable: false),
                    HyperLink = table.Column<string>(maxLength: 1073741791, nullable: false),
                    Title = table.Column<string>(maxLength: 1073741791, nullable: false),
                    ViewType = table.Column<string>(maxLength: 1073741791, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TDeveloperLinks", x => x.DeveloperLinkID);
                });

            migrationBuilder.CreateTable(
                name: "TDeveloperNotes",
                columns: table => new
                {
                    DeveloperNoteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeveloperID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 1073741791, nullable: true),
                    NoteContent = table.Column<string>(maxLength: 1073741791, nullable: true),
                    ViewType = table.Column<string>(maxLength: 1073741791, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TDeveloperNotes", x => x.DeveloperNoteID);
                });

            migrationBuilder.CreateTable(
                name: "TDeveloperPending",
                columns: table => new
                {
                    DeveloperPendingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(nullable: false),
                    DeveloperID = table.Column<int>(nullable: false),
                    OrderDesc = table.Column<string>(maxLength: 1073741791, nullable: true),
                    DateRequested = table.Column<DateTime>(nullable: false),
                    Budget = table.Column<string>(maxLength: 1073741791, nullable: true),
                    Requirements = table.Column<string>(maxLength: 1073741791, nullable: true),
                    DPStatus = table.Column<string>(maxLength: 1073741791, nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TDeveloperPending", x => x.DeveloperPendingID);
                });

            migrationBuilder.CreateTable(
                name: "TDeveloperProjects",
                columns: table => new
                {
                    DeveloperProjectID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeveloperID = table.Column<int>(nullable: false),
                    PreviewImageSrc = table.Column<string>(maxLength: 1073741791, nullable: false),
                    ThumbnailImageSrc = table.Column<string>(maxLength: 1073741791, nullable: false),
                    Alt = table.Column<string>(maxLength: 1073741791, nullable: false),
                    Title = table.Column<string>(maxLength: 1073741791, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TDeveloperProjects", x => x.DeveloperProjectID);
                });

            migrationBuilder.CreateTable(
                name: "TDevelopers",
                columns: table => new
                {
                    DeveloperID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 1073741791, nullable: false),
                    LastName = table.Column<string>(maxLength: 1073741791, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 1073741791, nullable: false),
                    Email = table.Column<string>(maxLength: 1073741791, nullable: false),
                    Password = table.Column<string>(maxLength: 1073741791, nullable: false),
                    Description = table.Column<string>(maxLength: 1073741791, nullable: false),
                    PLanguages = table.Column<string>(maxLength: 1073741791, nullable: false),
                    Skills = table.Column<string>(maxLength: 1073741791, nullable: false),
                    Education = table.Column<string>(maxLength: 1073741791, nullable: false),
                    Certification = table.Column<string>(maxLength: 1073741791, nullable: false),
                    Title = table.Column<string>(maxLength: 1073741791, nullable: false),
                    RoleID = table.Column<int>(nullable: false),
                    Photo = table.Column<string>(maxLength: 1073741791, nullable: true),
                    SideBarColor = table.Column<string>(maxLength: 1073741791, nullable: false),
                    DashboardColor = table.Column<string>(maxLength: 1073741791, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TDevelopers", x => x.DeveloperID);
                });

            migrationBuilder.CreateTable(
                name: "TDeveloperTasks",
                columns: table => new
                {
                    DeveloperTaskID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(nullable: false),
                    DeveloperID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 1073741791, nullable: true),
                    Description = table.Column<string>(maxLength: 1073741791, nullable: true),
                    Notes = table.Column<string>(maxLength: 1073741791, nullable: true),
                    Status = table.Column<string>(maxLength: 1073741791, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TDeveloperTasks", x => x.DeveloperTaskID);
                });

            migrationBuilder.CreateTable(
                name: "TOrders",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(nullable: false),
                    DeveloperID = table.Column<int>(nullable: false),
                    Price = table.Column<string>(maxLength: 1073741791, nullable: true),
                    CompletionDate = table.Column<DateTime>(nullable: false),
                    OrderDesc = table.Column<string>(maxLength: 1073741791, nullable: true),
                    Requirements = table.Column<string>(maxLength: 1073741791, nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(maxLength: 1073741791, nullable: true),
                    CustomerReview = table.Column<string>(maxLength: 1073741791, nullable: true),
                    Rating = table.Column<string>(maxLength: 1073741791, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TOrders", x => x.OrderID);
                });

            migrationBuilder.CreateTable(
                name: "TResourceManagerLinks",
                columns: table => new
                {
                    ResourceManagerLinkID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceManagerID = table.Column<int>(nullable: false),
                    HyperLink = table.Column<string>(maxLength: 1073741791, nullable: false),
                    Title = table.Column<string>(maxLength: 1073741791, nullable: false),
                    ViewType = table.Column<string>(maxLength: 1073741791, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TResourceManagerLinks", x => x.ResourceManagerLinkID);
                });

            migrationBuilder.CreateTable(
                name: "TResourceManagerNotes",
                columns: table => new
                {
                    ResourceManagerNotesID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceManagerID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 1073741791, nullable: true),
                    NoteContent = table.Column<string>(maxLength: 1073741791, nullable: true),
                    ViewType = table.Column<string>(maxLength: 1073741791, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TResourceManagerNotes", x => x.ResourceManagerNotesID);
                });

            migrationBuilder.CreateTable(
                name: "TResourceManagers",
                columns: table => new
                {
                    ResourceManagerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 1073741791, nullable: false),
                    LastName = table.Column<string>(maxLength: 1073741791, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 1073741791, nullable: false),
                    Email = table.Column<string>(maxLength: 1073741791, nullable: false),
                    Password = table.Column<string>(maxLength: 1073741791, nullable: false),
                    RoleID = table.Column<int>(nullable: false),
                    Photo = table.Column<string>(maxLength: 1073741791, nullable: true),
                    SideBarColor = table.Column<string>(maxLength: 1073741791, nullable: false),
                    DashboardColor = table.Column<string>(maxLength: 1073741791, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TResourceManagers", x => x.ResourceManagerID);
                });

            migrationBuilder.CreateTable(
                name: "TRMDeveloper",
                columns: table => new
                {
                    RMDeveloperID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceManagerID = table.Column<int>(nullable: false),
                    DeveloperID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRMDeveloper", x => x.RMDeveloperID);
                });

            migrationBuilder.CreateTable(
                name: "TRMInbox",
                columns: table => new
                {
                    RMInboxID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceManagerID = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 1073741791, nullable: true),
                    LastName = table.Column<string>(maxLength: 1073741791, nullable: true),
                    ChatMessage = table.Column<string>(maxLength: 1073741791, nullable: false),
                    MessageDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 1073741791, nullable: true),
                    Title = table.Column<string>(maxLength: 1073741791, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRMInbox", x => x.RMInboxID);
                });

            migrationBuilder.CreateTable(
                name: "TRoles",
                columns: table => new
                {
                    RoleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleDesc = table.Column<string>(maxLength: 1073741791, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRoles", x => x.RoleID);
                });
            migrationBuilder.Sql(
                @"
                        GO
                        /****** Object:  StoredProcedure [dbo].[AssignDevToRM]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[AssignDevToRM]
                        (
	                        @ResourceManagerID VARCHAR(MAX) , @DeveloperID varchar(max)
                        )
                        AS

                        INSERT INTO TRMDeveloper (ResourceManagerID , DeveloperID)
                        VALUES(@ResourceManagerID , @DeveloperID)


                        GO
                        /****** Object:  StoredProcedure [dbo].[CheckEmailExist]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[CheckEmailExist]
                        (
	                        @Email varchar(max)
                        )
                        AS
                        DECLARE @COUNT INT = 0
                        IF (SELECT count(*) from TCustomers where Email = @Email ) > 0
	                        BEGIN
	                        SET @COUNT = 1
	                        END

                        IF (SELECT count(*) from TDevelopers where Email = @Email ) > 0
	                        BEGIN
	                        SET @COUNT = 1
	                        END

                        IF (SELECT count(*) from TResourceManagers where Email = @Email ) > 0
	                        BEGIN
	                        SET @COUNT = 1
	                        END
                        select (@COUNT) as TOTAL
                        GO
                        /****** Object:  StoredProcedure [dbo].[CheckEmailPasswordExist]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[CheckEmailPasswordExist]
                        (
	                        @Email varchar(max), @Password varchar(max)
                        )
                        AS
                        DECLARE @COUNT INT = 0
                        IF (SELECT count(*) from TCustomers where Email = @Email and Password = @Password) > 0
	                        BEGIN
	                        SET @COUNT = 1
	                        END

                        IF (SELECT count(*) from TDevelopers where Email = @Email and Password = @Password) > 0
	                        BEGIN
	                        SET @COUNT = 1
	                        END

                        IF (SELECT count(*) from TResourceManagers where Email = @Email and Password = @Password) > 0
	                        BEGIN
	                        SET @COUNT = 1
	                        END
                        select (@COUNT) as TOTAL
                        GO
                        /****** Object:  StoredProcedure [dbo].[CreateDevLink]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[CreateDevLink]
                        (
	                        @DeveloperID varchar(max) , @Title varchar(max), @HyperLink varchar(max) , @ViewType varchar(max)
                        )
                        AS
                        INSERT INTO TDeveloperLinks (DeveloperID , Title , HyperLink , ViewType)
                        VALUES (@DeveloperID , @Title , @HyperLink , @ViewType)
                        GO
                        /****** Object:  StoredProcedure [dbo].[CreateDevNote]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[CreateDevNote]
                        (
	                         @DeveloperID varchar(max) , @Title varchar(max) , @ViewType varchar(max)
                        )
                        AS

                        INSERT INTO TDeveloperNotes (DeveloperID , Title , ViewType)
                        values (@DeveloperID , @Title , @ViewType)


                        GO
                        /****** Object:  StoredProcedure [dbo].[CreateRMLink]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[CreateRMLink]
                        (
	                        @ResourceManagerID varchar(max) , @Title varchar(max), @HyperLink varchar(max) , @ViewType varchar(max)
                        )
                        AS
                        INSERT INTO TResourceManagerLinks(ResourceManagerID , Title , HyperLink , ViewType)
                        VALUES ( @ResourceManagerID, @Title , @HyperLink , @ViewType)
                        GO
                        /****** Object:  StoredProcedure [dbo].[CreateRMNote]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[CreateRMNote]
                        (
	                         @ResourceManagerID varchar(max) , @Title varchar(max) , @ViewType varchar(max)
                        )
                        AS

                        INSERT INTO TResourceManagerNotes(ResourceManagerID , Title , ViewType)
                        values (@ResourceManagerID , @Title , @ViewType)


                        GO
                        /****** Object:  StoredProcedure [dbo].[DeleteDevGalleryPhoto]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[DeleteDevGalleryPhoto]
                        (
	                        @DeveloperProjectID varchar(50)
                        )
                        AS

                        DELETE FROM TDeveloperProjects where DeveloperProjectID = @DeveloperProjectID
                        GO
                        /****** Object:  StoredProcedure [dbo].[DeleteDevLink]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[DeleteDevLink]
                        (
	                        @DeveloperLinkID varchar(max) 
                        )
                        AS
                        DELETE FROM TDeveloperLinks where DeveloperLinkID = @DeveloperLinkID
                        GO
                        /****** Object:  StoredProcedure [dbo].[DeleteDevNote]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[DeleteDevNote]
                        (
	                         @DeveloperNoteID varchar(max) 
                        )
                        AS

                        DELETE FROM TDeveloperNotes WHERE DeveloperNoteID = @DeveloperNoteID

                        GO
                        /****** Object:  StoredProcedure [dbo].[DeleteRMLink]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[DeleteRMLink]
                        (
	                        @ResourceManagerLinkID varchar(max) 
                        )
                        AS
                        DELETE FROM TResourceManagerLinks where ResourceManagerLinkID = @ResourceManagerLinkID
                        GO
                        /****** Object:  StoredProcedure [dbo].[DeleteRMNote]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[DeleteRMNote]
                        (
	                         @ResourceManagerNotesID varchar(max) 
                        )
                        AS

                        DELETE FROM TResourceManagerNotes WHERE ResourceManagerNotesID = @ResourceManagerNotesID

                        GO
                        /****** Object:  StoredProcedure [dbo].[DeleteTask]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[DeleteTask]
                        (
	                        @DeveloperTaskID varchar(50)
                        )
                        AS
                        DELETE FROM TDeveloperTasks where DeveloperTaskID  = @DeveloperTaskID
                        GO
                        /****** Object:  StoredProcedure [dbo].[DevHistoryCustomerReview]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[DevHistoryCustomerReview]
                        (
	                         @DeveloperID varchar(max)
                        )
                        AS

                        SELECT OrderID as OrderNumber , Rating , CustomerReview
                        FROM TOrders 
                        WHERE DeveloperID = @DeveloperID and Status = 'Complete'


                        GO
                        /****** Object:  StoredProcedure [dbo].[GetCustomerDevelopedOrders]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetCustomerDevelopedOrders]
                        (
	                        @CustomerID varchar(50)
                        )
                        AS
                        SELECT O.OrderID as OrderNumber , O.CustomerID , D.FirstName + ' ' + D.LastName as DeveloperName , O.OrderDesc AS Description , 
		                        O.Requirements , convert(varchar, O.CompletionDate, 20) AS CompletionDate , O.Status
                        FROM TOrders as O INNER JOIN TDevelopers as D on O.DeveloperID = D.DeveloperID
                        WHERE O.CustomerID = @CustomerID and O.Status = 'Developed'

                        GO
                        /****** Object:  StoredProcedure [dbo].[GetCustomerInbox]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetCustomerInbox]
                        (
	                        @CustomerID varchar(50)
                        )
                        AS

                        SELECT CI.CustomerID as ID, CI.FirstName + ' ' + CI.LastName as Name , CI.Email, CI.Title as Subject, CI.ChatMessage as Message ,  LEFT(CONVERT(VARCHAR, CI.MessageDate, 120), 10) as RecievedDate FROM TCustomerInbox CI INNER JOIN TCustomers C on CI.CustomerID = C.CustomerID where C.CustomerID = @CustomerID order by RecievedDate DESC
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetCustomerInfo]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetCustomerInfo]
                        (
	                        @Email varchar(max) , @Password varchar(max)
                        )
                        AS
                        DECLARE @RoleID varchar(50)
                        SET @RoleID = '1' 
                        SELECT C.CustomerID , C.FirstName , C.LastName , C.PhoneNumber , C.Email , C.Password , r.RoleDesc , C.Photo , C.SideBarColor , C.DashboardColor FROM TCustomers as C , TRoles as r WHERE C.RoleID = r.RoleID and C.Password = @Password and C.Email = @Email
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetCustomerInfoByID]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetCustomerInfoByID]
                        (
	                        @ID varchar(max) 
                        )
                        AS
                        DECLARE @RoleID varchar(50)
                        SET @RoleID = '1' 
                        SELECT C.CustomerID , C.FirstName , C.LastName , C.PhoneNumber , C.Email , C.Password , r.RoleDesc , C.Photo , C.SideBarColor, C.DashboardColor FROM TCustomers as C , TRoles as r WHERE C.RoleID = r.RoleID and C.CustomerID = @ID
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetCustomerOpenOrders]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetCustomerOpenOrders]
                        (
	                        @CustomerID varchar(50)
                        )
                        AS
                        SELECT O.OrderID as OrderNumber , O.CustomerID , D.FirstName + ' ' + D.LastName as DeveloperName , O.OrderDesc AS Description , 
		                        O.Requirements , convert(varchar, O.CompletionDate, 20) AS CompletionDate , O.Status
                        FROM TOrders as O INNER JOIN TDevelopers as D on O.DeveloperID = D.DeveloperID
                        WHERE O.CustomerID = @CustomerID and O.Status = 'In Progress'

                        GO
                        /****** Object:  StoredProcedure [dbo].[GetCustomerOrderHistory]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetCustomerOrderHistory]
                        (
	                        @CustomerID varchar(50)
                        )
                        AS
                        SELECT O.OrderID as OrderNumber , D.FirstName + ' ' + D.LastName as DeveloperName , O.OrderDesc AS Description , 
		                        O.Requirements , convert(varchar, O.CompletionDate, 20) AS CompletionDate , O.Rating , O.CustomerReview
                        FROM TOrders as O INNER JOIN TDevelopers as D on O.DeveloperID = D.DeveloperID
                        WHERE O.CustomerID = @CustomerID and O.Status = 'Complete'

                        GO
                        /****** Object:  StoredProcedure [dbo].[GetCustomerPendingApproval]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetCustomerPendingApproval]
                        (
	                        @CustomerID	 varchar(50)
                        )
                        AS

                        SELECT CP.CustomerPendingID , CP.CustomerID , CP.DeveloperID , CP.OrderDesc , convert(varchar, CP.DateOffered, 20) as DateOffered , CP.PriceOffered , CP.Requirements , D.FirstName + ' ' + D.LastName as Name
                        FROM TCustomerPending as CP INNER JOIN TDevelopers as D ON CP.DeveloperID = D.DeveloperID 
                        WHERE CP.CustomerID = @CustomerID and CP.CPStatus = 'unreplied'
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetCustomerPendingDeclined]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetCustomerPendingDeclined]
                        (
	                        @CustomerID varchar(50)
                        )
                        AS

                        SELECT DeveloperDeclinedID , D.FirstName + ' ' + D.LastName as DeveloperName , DD.OrderDescription , convert(varchar, DD.DeclinedDate, 20) as DeclinedDate , DD.DeclineReason 
                        FROM TDeveloperDeclined DD INNER JOIN TDevelopers AS D ON DD.DeveloperID = d.DeveloperID , TDeveloperPending AS DP INNER JOIN TCustomers as C ON DP.CustomerID = C.CustomerID
                        WHERE DD.DeveloperPendingID = DP.DeveloperPendingID and DP.CustomerID = @CustomerID and DP.DPStatus = 'declined'







                        GO
                        /****** Object:  StoredProcedure [dbo].[GetCustomerPendingOrders]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetCustomerPendingOrders]
                        (
	                        @CustomerID	 varchar(50)
                        )
                        AS

                        SELECT DP.DeveloperPendingID , DP.OrderDesc as Description , convert(varchar, DP.DateRequested, 20) as 'Desired_Completion_Date' , convert(varchar, DP.DateCreated , 20) AS DateCreated 
                        , DP.Budget , DP.Requirements ,  D.FirstName + ' ' + D.LastName as Name
                        FROM TDeveloperPending as DP INNER JOIN TDevelopers as D ON DP.DeveloperID = D.DeveloperID 
                        WHERE DP.CustomerID = @CustomerID AND dp.DPStatus = 'unreplied'


                        GO
                        /****** Object:  StoredProcedure [dbo].[GetCustomerSentMessages]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetCustomerSentMessages]
                        (
	                        @CustomerID varchar(50) , @Number varchar(50)
                        )
                        AS
                        DECLARE @Email varchar(max) 
                        SET @Email = (SELECT Email FROM TCustomers WHERE CustomerID = @CustomerID)
                        IF @Number = '1'
	                        BEGIN
	                        SELECT CONVERT(varchar(max),DI.DeveloperInboxID) + 'DeveloperInbox'  as ID, DI.FirstName + ' ' + DI.LastName as Name , DI.Title as Subject, DI.ChatMessage as Message ,  LEFT(CONVERT(VARCHAR, DI.MessageDate, 120), 10) as SentDate 
	                        FROM TDeveloperInbox DI INNER JOIN TCustomers C on DI.Email = C.Email
	                        where C.CustomerID = @CustomerID 
	                        order by SentDate DESC
	                        END
                        IF @Number = '2'
	                        BEGIN
	                        SELECT CONVERT(varchar(max),RI.RMInboxID)  + 'RMInboxID' as ID, RI.FirstName + ' ' + RI.LastName as Name , RI.Title as Subject, RI.ChatMessage as Message ,  LEFT(CONVERT(VARCHAR, RI.MessageDate, 120), 10) as SentDate 
	                        FROM TRMInbox RI INNER JOIN TCustomers C on RI.Email = C.Email
	                        where C.CustomerID = @CustomerID 
	                        order by SentDate DESC
	                        END
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetDeveloperInbox]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetDeveloperInbox]
                        (
	                        @DeveloperID varchar(50)
                        )
                        AS

                        SELECT DI.DeveloperID as ID,  DI.FirstName + ' ' + DI.LastName as Name , DI.Email , DI.Title as Subject,  DI.ChatMessage as Message ,  LEFT(CONVERT(VARCHAR, DI.MessageDate, 120), 10) as RecievedDate 
                        FROM TDeveloperInbox DI INNER JOIN TDevelopers D on DI.DeveloperID = D.DeveloperID where D.DeveloperID = @DeveloperID
                        order by RecievedDate DESC
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetDeveloperInfo]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetDeveloperInfo]
                        (
	                        @Email varchar(max) , @Password varchar(max)
                        )
                        AS
                        DECLARE @RoleID varchar(50)
                        SET @RoleID = '2' 
                        SELECT D.DeveloperID , D.FirstName , D.LastName , D.PhoneNumber , D.Email , D.Password , D.Description , D.PLanguages , D.Skills, D.Education , D.Certification , D.Title, r.RoleDesc , D.Photo , D.SideBarColor ,D.DashboardColor FROM TDevelopers as D , TRoles as r WHERE D.RoleID = r.RoleID and D.Password = @Password and D.Email = @Email
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetDeveloperInfoByID]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetDeveloperInfoByID]
                        (
	                        @ID varchar(50)
                        )
                        AS
                        DECLARE @RoleID varchar(50)
                        SET @RoleID = '2' 
                        SELECT D.DeveloperID , D.FirstName , D.LastName , D.PhoneNumber , D.Email , D.Password , D.Description , D.PLanguages , D.Skills, D.Education , D.Certification , D.Title, r.RoleDesc , D.Photo , D.SideBarColor , D.DashboardColor
                        FROM TDevelopers as D , TRoles as r WHERE 
                        D.RoleID = r.RoleID and D.DeveloperID = @ID
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetDeveloperLinks]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetDeveloperLinks]
                        (
	                        @DeveloperID varchar(max) 
                        )
                        AS
                        select DL.DeveloperLinkID , dl.Title , dl.HyperLink , dl.ViewType
                        from TDeveloperLinks as DL
                        where dl.DeveloperID = @DeveloperID
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetDeveloperNotes]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetDeveloperNotes]
                        (
	                         @DeveloperID varchar(max) 
                        )
                        AS

                        select DeveloperNoteID , Title , NoteContent , ViewType
                        from TDeveloperNotes
                        where DeveloperID = @DeveloperID

                        GO
                        /****** Object:  StoredProcedure [dbo].[GetDevGalleryInfo]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetDevGalleryInfo]
                        (
	                        @DeveloperID varchar(50)
                        )
                        AS

                        Select DeveloperID,PreviewImageSrc,ThumbnailImageSrc,Alt,Title FROM TDeveloperProjects where DeveloperID = @DeveloperID
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetDevGalleryTable]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetDevGalleryTable]
                        (
	                        @DeveloperID varchar(50)
                        )
                        AS

                        Select DeveloperProjectID as ImageID ,Title , Alt as Description , PreviewImageSrc as imagesrc FROM TDeveloperProjects where DeveloperID = @DeveloperID
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetDevList_CustomerDashboard]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetDevList_CustomerDashboard]
                        AS

                        SELECT DeveloperID, FirstName + ' ' + LastName as Name , Email , Photo , PLanguages
                        FROM TDevelopers


                        GO
                        /****** Object:  StoredProcedure [dbo].[GetDevList_RMDevelopers]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetDevList_RMDevelopers]
                        (
	                        @ResourceManagerID VARCHAR(MAX)
                        )
                        AS

                        SELECT D.DeveloperID, D.FirstName + ' ' + D.LastName as Name, D.Email , D.Photo , D.PLanguages
                        FROM TResourceManagers AS RM , TDevelopers as D , TRMDeveloper as RMD
                        where RMD.ResourceManagerID = RM.ResourceManagerID AND RMD.DeveloperID = D.DeveloperID AND D.DeveloperID IN (SELECT DeveloperID FROM TRMDeveloper where ResourceManagerID = @ResourceManagerID)


                        GO
                        /****** Object:  StoredProcedure [dbo].[GetDevListBox_Customer]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetDevListBox_Customer]

                        AS

                        SELECT D.Email , D.FirstName + ' ' + D.LastName as Name , R.RoleDesc as Role  FROM TDevelopers as D INNER JOIN TRoles as R on D.RoleID = R.RoleID
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetDevNotAssignedToRM]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetDevNotAssignedToRM]
                        (
	                        @ResourceManagerID VARCHAR(MAX)
                        )
                        AS

                        SELECT D.DeveloperID, D.FirstName + ' ' + D.LastName AS Name, D.Email , D.Photo , D.PLanguages 
                        FROM TDevelopers as D 
                        WHERE DeveloperID NOT IN (SELECT DeveloperID FROM TRMDeveloper where ResourceManagerID = @ResourceManagerID)

                        GO
                        /****** Object:  StoredProcedure [dbo].[GetDevOpenOrders]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetDevOpenOrders]
                        (
	                        @DeveloperID varchar(50)
                        )
                        AS

                        SELECT O.OrderID as OrderNumber , O.DeveloperID , C.FirstName + ' ' + c.LastName as CustomerName , O.OrderDesc as Description , O.Requirements , convert(varchar, O.CompletionDate , 20)  as CompletionDate , O.Status
                        FROM TOrders as O inner join TCustomers as C on O.CustomerID = C.CustomerID
                        WHERE O.DeveloperID = @DeveloperID and O.Status = 'In Progress'

                        GO
                        /****** Object:  StoredProcedure [dbo].[GetDevOrderHistory]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetDevOrderHistory]
                        (
	                        @DeveloperID varchar(50)
                        )
                        AS
                        SELECT O.OrderID as OrderNumber , C.FirstName + ' ' + C.LastName as CustomerName , O.OrderDesc AS Description , 
		                        O.Requirements , convert(varchar, O.CompletionDate, 20) AS CompletionDate , O.Rating , O.CustomerReview
                        FROM TOrders as O INNER JOIN TCustomers as C on O.DeveloperID = C.CustomerID
                        WHERE O.DeveloperID = @DeveloperID and O.Status = 'Complete'
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetDevOrderHistory_RM]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetDevOrderHistory_RM]
                        (
	                        @ResourceManagerID varchar(max) 
                        )
                        AS
                        SELECT O.OrderID as OrderNumber , D.FirstName + ' ' + D.LastName as DeveloperName, C.FirstName + ' ' + C.LastName as CustomerName , O.OrderDesc AS Description , 
		                        O.Requirements , convert(varchar, O.CompletionDate, 20) AS CompletionDate , O.Rating , O.CustomerReview
                        FROM TOrders as O INNER JOIN TCustomers as C on O.DeveloperID = C.CustomerID INNER JOIN TDevelopers as D on O.DeveloperID = D.DeveloperID
                        WHERE O.DeveloperID IN (SELECT DeveloperID from TRMDeveloper where ResourceManagerID = @ResourceManagerID)
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetDevPendingCustomerOrders]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetDevPendingCustomerOrders]
                        (
	                        @DeveloperID varchar(50)
                        )
                        AS

                        SELECT CP.CustomerPendingID , C.FirstName + ' ' + C.LastName as Name , CP.OrderDesc AS Description , CP.PriceOffered , CP.Requirements , convert(varchar, CP.DateOffered, 20) as DateOffered , convert(varchar, CP.DateCreated, 20) as DateAccepted
                        FROM TCustomerPending AS CP INNER JOIN TCustomers AS C on CP.CustomerID = C.CustomerID
                        WHERE CP.DeveloperID = @DeveloperID and CP.CPStatus = 'unreplied'


                        GO
                        /****** Object:  StoredProcedure [dbo].[GetDevPendingOrders]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetDevPendingOrders]
                        (
	                        @DeveloperID varchar(50)
                        )
                        AS

                        SELECT DP.DeveloperPendingID , DP.CustomerID , DP.DeveloperID , DP.OrderDesc , convert(varchar, DP.DateRequested, 20) as DateRequested , DP.Budget , DP.Requirements , c.FirstName + ' ' + C.LastName as Name
                        FROM TDeveloperPending as DP INNER JOIN TCustomers as C ON DP.CustomerID = C.CustomerID 
                        WHERE DP.DeveloperID = @DeveloperID and dp.DPStatus = 'unreplied'
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetDevRMListBox_Customer]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetDevRMListBox_Customer]

                        AS

                        SELECT C.Email , C.FirstName + ' ' + C.LastName as Name , R.RoleDesc as Role , C.Photo FROM TCustomers as C INNER JOIN TRoles as R on C.RoleID = R.RoleID
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetDevRMListBox_Dev]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetDevRMListBox_Dev]

                        AS

                        SELECT D.Email , D.FirstName + ' ' + D.LastName as Name , R.RoleDesc as Role , D.Photo  FROM TDevelopers as D INNER JOIN TRoles as R on D.RoleID = R.RoleID
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetDevRMListBox_RM]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetDevRMListBox_RM]

                        AS

                        SELECT RM.Email, RM.FirstName + ' ' + RM.LastName as Name , R.RoleDesc as Role , RM.Photo  FROM TResourceManagers as RM INNER JOIN TRoles as R on RM.RoleID = R.RoleID
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetDevRMOpenOrders]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetDevRMOpenOrders]
                        (
	                        @ResourceManagerID varchar(50)
                        )
                        AS

                        SELECT O.OrderID as OrderNumber , O.DeveloperID , O.CustomerID , D.FirstName + ' ' + D.LastName as DeveloperName ,  C.FirstName + ' ' + c.LastName as CustomerName ,  
		                        O.OrderDesc as Description , O.Requirements , convert(varchar, O.CompletionDate , 20)  as CompletionDate , O.Price ,  O.Status
                        FROM TOrders as O inner join TCustomers as C on O.CustomerID = C.CustomerID inner join TDevelopers as D on O.DeveloperID = D.DeveloperID  , TRMDeveloper as RMD
                        WHERE O.DeveloperID IN (SELECT DeveloperID FROM TRMDeveloper where ResourceManagerID = @ResourceManagerID) and O.Status = 'In Progress'

                        GO
                        /****** Object:  StoredProcedure [dbo].[GetDevSentMessages]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetDevSentMessages]
                        (
	                        @DeveloperID varchar(50) , @Number varchar(50)
                        )
                        AS
                        DECLARE @Email varchar(max) 
                        SET @Email = (SELECT Email FROM TDevelopers WHERE DeveloperID = @DeveloperID)

                        IF @Number = '1'
	                        BEGIN
	                        SELECT CONVERT(varchar(max),DI.DeveloperInboxID) + 'DeveloperInbox'   as ID, DI.FirstName + ' ' + DI.LastName as Name , DI.Title as Subject, DI.ChatMessage as Message ,  LEFT(CONVERT(VARCHAR, DI.MessageDate, 120), 10) as SentDate 
	                        FROM TDeveloperInbox DI INNER JOIN TDevelopers D on DI.Email = D.Email
	                        where D.DeveloperID = @DeveloperID 
	                        order by SentDate DESC
	                        END
                        IF @Number = '2'
	                        BEGIN
	                        SELECT CONVERT(varchar(max),RI.RMInboxID) + 'RMInboxID'   as ID, RI.FirstName + ' ' + RI.LastName as Name , RI.Title as Subject, RI.ChatMessage as Message ,  LEFT(CONVERT(VARCHAR, RI.MessageDate, 120), 10) as SentDate 
	                        FROM TRMInbox RI INNER JOIN TDevelopers D on RI.Email = D.Email
	                        where D.DeveloperID = @DeveloperID 
	                        order by SentDate DESC
	                        END
                        IF @Number = '3'
	                        BEGIN
	                        SELECT CONVERT(varchar(max),CI.CustomerInboxID) + 'CustomerInboxID'  as ID, CI.FirstName + ' ' + CI.LastName as Name , CI.Title as Subject, CI.ChatMessage as Message ,  LEFT(CONVERT(VARCHAR, CI.MessageDate, 120), 10) as SentDate 
	                        FROM TCustomerInbox CI INNER JOIN TDevelopers D on CI.Email = D.Email
	                        where D.DeveloperID = @DeveloperID 
	                        order by SentDate DESC
	                        END
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetOrderTasks]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetOrderTasks]
                        (
	                        @OrderID varchar(50)
                        )
                        AS
                        SELECT DT.DeveloperTaskID , DT.OrderID as OrderNumber , DT.Title , DT.Description , DT.Notes , DT.Status
                        FROM TDeveloperTasks as DT
                        WHERE DT.OrderID = @OrderID
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetPendingCustomerResponse_RM]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetPendingCustomerResponse_RM]
                        (
	                        @ResourceManagerID varchar(max) 
                        )
                        AS
                        SELECT CP.CustomerPendingID , D.FirstName + ' ' + D.LastName as DeveloperName , C.FirstName + ' ' + C.LastName as CustomerName , CP.OrderDesc as Description , CP.Requirements , 
		                        CP.PriceOffered , convert(varchar, CP.DateOffered, 20) AS DateOffered , convert(varchar, CP.DateCreated, 20) AS DevAcceptedDate  
                        FROM TCustomerPending as CP , TCustomers AS C , TDevelopers AS D
                        WHERE CP.DeveloperID = D.DeveloperID and CP.CustomerID = C.CustomerID and CP.CPStatus = 'unreplied'
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetPendingDevResponse_RM]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetPendingDevResponse_RM]
                        (
	                        @ResourceManagerID varchar(max) 
                        )
                        AS
                        SELECT DP.DeveloperPendingID , D.FirstName + ' ' + D.LastName as DeveloperName , C.FirstName + ' ' + C.LastName as CustomerName , DP.OrderDesc as Description , DP.Requirements , 
		                        DP.Budget , convert(varchar, DP.DateRequested, 20) AS DateRequested , convert(varchar, DP.DateCreated, 20) AS CreatedDate  
                        FROM TDeveloperPending as DP , TCustomers AS C , TDevelopers AS D
                        WHERE DP.DeveloperID = D.DeveloperID and DP.CustomerID = C.CustomerID and DP.DPStatus = 'unreplied'
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetPublicLinks_Dev]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetPublicLinks_Dev]
                        (
	                        @DeveloperID varchar(max) , @Selection varchar(max)
                        )
                        AS
                        IF @Selection = '1'
	                        BEGIN
	                        SELECT DL.DeveloperLinkID as LinkID	, DL.Title , DL.HyperLink , R.RoleDesc
	                        FROM TDeveloperLinks as DL , TRoles as R , TDevelopers as D
	                        WHERE DL.DeveloperID = D.DeveloperID and D.RoleID = R.RoleID and DL.DeveloperID != @DeveloperID and DL.ViewType = 'Public'
	                        END
                        IF @Selection = '2'
	                        BEGIN
	                        SELECT RL.ResourceManagerLinkID as LinkID	, RL.Title , RL.HyperLink , R.RoleDesc
	                        FROM TResourceManagerLinks as RL , TRoles as R , TResourceManagers as RM
	                        WHERE  RL.ResourceManagerID = RM.ResourceManagerID and RM.RoleID = R.RoleID and RL.ViewType = 'Public'
	                        END
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetPublicLinks_RM]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetPublicLinks_RM]	
                        (
	                        @ResourceManagerID varchar(max) , @Selection varchar(max)
                        )
                        AS
                        IF @Selection = '1'
	                        BEGIN
	                        SELECT DL.DeveloperLinkID as LinkID	, DL.Title , DL.HyperLink , R.RoleDesc
	                        FROM TDeveloperLinks as DL , TRoles as R , TDevelopers as D
	                        WHERE DL.DeveloperID = D.DeveloperID and D.RoleID = R.RoleID  and DL.ViewType = 'Public'
	                        END
                        IF @Selection = '2'
	                        BEGIN
	                        SELECT RL.ResourceManagerLinkID as LinkID	, RL.Title , RL.HyperLink , R.RoleDesc
	                        FROM TResourceManagerLinks as RL , TRoles as R , TResourceManagers as RM
	                        WHERE  RL.ResourceManagerID = RM.ResourceManagerID and RM.RoleID = R.RoleID and RL.ResourceManagerID != @ResourceManagerID and RL.ViewType = 'Public'
	                        END
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetPublicNotes_Dev]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetPublicNotes_Dev]
                        (
	                         @DeveloperID varchar(max) , @Selection VARCHAR(MAX)
                        )
                        AS

                        IF @Selection = '1'
	                        BEGIN
	                        SELECT DN.DeveloperNoteID as NoteID	, DN.Title , DN.NoteContent , R.RoleDesc
	                        FROM TDeveloperNotes as DN , TRoles as R , TDevelopers as D
	                        WHERE DN.DeveloperID = D.DeveloperID and D.RoleID = R.RoleID and DN.DeveloperID != @DeveloperID and DN.ViewType = 'Public'
	                        END
                        IF @Selection = '2'
	                        BEGIN
	                        SELECT RN.ResourceManagerNotesID as LinkID	, RN.Title , RN.NoteContent , R.RoleDesc
	                        FROM TResourceManagerNotes as RN , TRoles as R , TResourceManagers as RM
	                        WHERE  RN.ResourceManagerID = RM.ResourceManagerID and RM.RoleID = R.RoleID and RN.ViewType = 'Public'
	                        END
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetPublicNotes_RM]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetPublicNotes_RM]
                        (
	                         @ResourceManagerID varchar(max) , @Selection VARCHAR(MAX)
                        )
                        AS

                        IF @Selection = '1'
	                        BEGIN
	                        SELECT DN.DeveloperNoteID as NoteID	, DN.Title , DN.NoteContent , R.RoleDesc
	                        FROM TDeveloperNotes as DN , TRoles as R , TDevelopers as D
	                        WHERE DN.DeveloperID = D.DeveloperID and D.RoleID = R.RoleID  and DN.ViewType = 'Public'
	                        END
                        IF @Selection = '2'
	                        BEGIN
	                        SELECT RN.ResourceManagerNotesID as NoteID	, RN.Title , RN.NoteContent , R.RoleDesc
	                        FROM TResourceManagerNotes as RN , TRoles as R , TResourceManagers as RM
	                        WHERE  RN.ResourceManagerID = RM.ResourceManagerID and RM.RoleID = R.RoleID and RN.ResourceManagerID != @ResourceManagerID and RN.ViewType = 'Public'
	                        END
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetResourceManagerInfo]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetResourceManagerInfo]
                        (
	                        @Email varchar(max) , @Password varchar(max)
                        )
                        AS
                        DECLARE @RoleID varchar(50)
                        SET @RoleID = '1' 
                        SELECT RM.ResourceManagerID , RM.FirstName , RM.LastName , RM.PhoneNumber , RM.Email , RM.Password , r.RoleDesc , RM.Photo , RM.SideBarColor , RM.DashboardColor 
                        FROM TResourceManagers as RM , TRoles as r 
                        WHERE RM.RoleID = r.RoleID and RM.Password = @Password and RM.Email = @Email
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetResourceManagerInfoByID]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetResourceManagerInfoByID]
                        (
	                        @ID varchar(max) 
                        )
                        AS
                        DECLARE @RoleID varchar(50)
                        SET @RoleID = '1' 
                        SELECT RM.ResourceManagerID , RM.FirstName , RM.LastName , RM.PhoneNumber , RM.Email , RM.Password , r.RoleDesc , RM.Photo , RM.SideBarColor , RM.DashboardColor 
                        FROM TResourceManagers as RM , TRoles as r 
                        WHERE RM.RoleID = r.RoleID and rm.ResourceManagerID = @ID
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetRMInbox]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetRMInbox]
                        (
	                        @ResourceManagerID varchar(50)
                        )
                        AS

                        SELECT RI.ResourceManagerID as ID , RI.FirstName + ' ' + RI.LastName as Name , RI.Email , RI.Title as Subject, RI.ChatMessage as Message ,  LEFT(CONVERT(VARCHAR, RI.MessageDate, 120), 10) as RecievedDate 
                        FROM TRMInbox RI INNER JOIN TResourceManagers R on RI.ResourceManagerID = R.ResourceManagerID where R.ResourceManagerID = @ResourceManagerID
                        order by RecievedDate DESC
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetRMLinks]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetRMLinks]
                        (
	                        @ResourceManagerID varchar(max) 
                        )
                        AS
                        select RL.ResourceManagerLinkID , RL.Title , RL.HyperLink , RL.ViewType
                        from TResourceManagerLinks as RL
                        where RL.ResourceManagerID = @ResourceManagerID
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetRMNotes]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetRMNotes]
                        (
	                         @ResourceManagerID varchar(max) 
                        )
                        AS

                        select ResourceManagerNotesID , Title , NoteContent , ViewType
                        from TResourceManagerNotes
                        where ResourceManagerID = @ResourceManagerID

                        GO
                        /****** Object:  StoredProcedure [dbo].[GetRMSentMessages]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetRMSentMessages]
                        (
	                        @ResourceManagerID varchar(50) , @Number varchar(50)
                        )
                        AS
                        DECLARE @Email varchar(max) 
                        SET @Email = (SELECT Email FROM TResourceManagers WHERE ResourceManagerID = @ResourceManagerID)

                        IF @Number = '1'
	                        BEGIN
	                        SELECT CONVERT(varchar(max),DI.DeveloperInboxID) + 'DeveloperInboxID'  as ID, DI.FirstName + ' ' + DI.LastName as Name , DI.Title as Subject, DI.ChatMessage as Message ,  LEFT(CONVERT(VARCHAR, DI.MessageDate, 120), 10) as SentDate 
	                        FROM TDeveloperInbox DI INNER JOIN TResourceManagers RM on DI.Email = RM.Email
	                        where RM.ResourceManagerID = @ResourceManagerID 
	                        order by SentDate DESC
	                        END
                        IF @Number = '2'
	                        BEGIN
	                        SELECT CONVERT(varchar(max),RI.RMInboxID) + 'RMInboxID'  as ID, RI.FirstName + ' ' + RI.LastName as Name , RI.Title as Subject, RI.ChatMessage as Message ,  LEFT(CONVERT(VARCHAR, RI.MessageDate, 120), 10) as SentDate 
	                        FROM TRMInbox RI INNER JOIN TResourceManagers RM on RI.Email = RM.Email
	                        where RM.ResourceManagerID = @ResourceManagerID 
	                        order by SentDate DESC
	                        END
                        IF @Number = '3'
	                        BEGIN
	                        SELECT CONVERT(varchar(max),CI.CustomerInboxID) + 'CustomerInboxID' as ID, CI.FirstName + ' ' + CI.LastName as Name , CI.Title as Subject, CI.ChatMessage as Message ,  LEFT(CONVERT(VARCHAR, CI.MessageDate, 120), 10) as SentDate 
	                        FROM TCustomerInbox CI INNER JOIN TResourceManagers RM on CI.Email = RM.Email
	                        where RM.ResourceManagerID = @ResourceManagerID  
	                        order by SentDate DESC
	                        END
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetUserPasswordFromEmail]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[GetUserPasswordFromEmail]
                        (
	                        @Email varchar(MAX)
                        )
                        AS

                        IF (SELECT count(*) from TCustomers where Email = @Email) > 0
	                        BEGIN
	                        SELECT Password FROM TCustomers where Email = @Email
	                        END

                        IF (SELECT count(*) from TDevelopers where Email = @Email) > 0
	                        BEGIN
	                        SELECT Password FROM TDevelopers where Email = @Email
	                        END

                        IF (SELECT count(*) from TResourceManagers where Email = @Email) > 0
	                        BEGIN
	                        SELECT Password FROM TResourceManagers where Email = @Email
	                        END
                        GO
                        /****** Object:  StoredProcedure [dbo].[InsertDevGalleryPhoto]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[InsertDevGalleryPhoto]
                        (
	                        @Email varchar(max) , @NewPhoto varchar(max)  , @Description varchar(max) , @Title varchar(max)
                        )
                        AS
                        DECLARE @DeveloperID varchar(50)
                        SET @DeveloperID = (SELECT DeveloperID FROM TDevelopers where Email = @Email)
                        INSERT INTO TDeveloperProjects(DeveloperID,PreviewImageSrc,ThumbnailImageSrc,Alt,Title)
                        Values (@DeveloperID,@NewPhoto,@NewPhoto,@Description,@Title)
                        GO
                        /****** Object:  StoredProcedure [dbo].[InsertNewCustomer]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[InsertNewCustomer]
                        (
	                        @FirstName varchar(max), @LastName varchar(max) , @PhoneNumber varchar(max) , @Email varchar(max) , @Password varchar(max)
                        )
                        AS
                        DECLARE @RoleID varchar(50)
                        SET @RoleID = '1'
                        INSERT INTO TCustomers(FirstName,LastName,PhoneNumber,Email,Password,RoleID)
                        VALUES (@FirstName,@LastName,@PhoneNumber,@Email,@Password,@RoleID)
                        GO
                        /****** Object:  StoredProcedure [dbo].[InsertNewDeveloper]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[InsertNewDeveloper]
                        ( 
	                        @FirstName varchar(max), @LastName varchar(max) , @PhoneNumber varchar(max) , @Email varchar(max) , @Password varchar(max), @Description varchar(max) , @PLanguages varchar(max) , @Skills varchar(max), @Education varchar(max), @Certifications varchar(max), @DesiredTitle varchar(max)
                        )
                        AS
                        DECLARE @RoleID varchar(50)
                        SET @RoleID = '2'
                        INSERT INTO TDevelopers(FirstName,LastName,PhoneNumber,Email,Password , Description , PLanguages , Skills , Education ,Certification ,Title , RoleID)
                        VALUES (@FirstName,@LastName,@PhoneNumber,@Email,@Password,@Description ,@PLanguages ,  @Skills , @Education ,@Certifications ,@DesiredTitle , @RoleID  )

                        DECLARE @DeveloperID varchar(50)
                        SET @DeveloperID = (
                        SELECT DeveloperID FROM TDevelopers WHERE FirstName = @FirstName and LastName = @LastName and Email = @Email and Password = @Password)
                        INSERT INTO TDeveloperProjects (DeveloperID, PreviewImageSrc , ThumbnailImageSrc, Alt , Title)
                        VALUES(@DeveloperID , 'https://localhost:44380/MyStaticFiles/Profile/default/profile1.jpg' , 'https://localhost:44380/MyStaticFiles/Profile/default/profile1.jpg' ,'Default Image 1 , Here is Where Description Goes' ,'Amazing View'),
                        (@DeveloperID , 'https://localhost:44380/MyStaticFiles/Profile/default/profile2.jpg' , 'https://localhost:44380/MyStaticFiles/Profile/default/profile2.jpg' ,'Default Image 2 , Here is Where Description Goes' ,'Artistic'),
                        (@DeveloperID , 'https://localhost:44380/MyStaticFiles/Profile/default/profile3.jpg' , 'https://localhost:44380/MyStaticFiles/Profile/default/profile3.jpg' ,'Default Image 3 , Here is Where Description Goes' ,'Nature')
                        GO
                        /****** Object:  StoredProcedure [dbo].[InsertNewOrder]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[InsertNewOrder]
                        (
	                        @CustomerID varchar(50), @DevEmail varchar(max) , @OrderDesc varchar(max) , @OrderRequirments varchar(max) , @Budget varchar(max) , @DateBy varchar(max)
                        )
                        AS
                        DECLARE @DeveloperID varchar(50)
                        SET @DeveloperID = (select DeveloperID FROM TDevelopers WHERE Email = @DevEmail)
                        INSERT INTO TDeveloperPending(DeveloperID,CustomerID,OrderDesc , DateRequested , Budget , Requirements , DPStatus  , DateCreated)
                        VALUES (@DeveloperID , @CustomerID , @OrderDesc , @DateBy , @Budget , @OrderRequirments , 'unreplied' , GETDATE())


                        GO
                        /****** Object:  StoredProcedure [dbo].[InsertNewOrderDevCustomerApproved]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[InsertNewOrderDevCustomerApproved]
                        (
	                        @CustomerPendingID varchar(50) , @CustomerID VARCHAR(50) , @DeveloperID VARCHAR(50) , @Price varchar(max) , @CompletionDate varchar(max),
	                        @OrderDesc varchar(max) , @Requirements varchar(max)
                        )

                        AS

                        UPDATE TCustomerPending  set CPStatus = 'replied' WHERE CustomerPendingID = @CustomerPendingID

                        INSERT INTO TOrders (CustomerID , DeveloperID , Price , CompletionDate , OrderDesc , Requirements , DateCreated , Status)
                        VALUES (@CustomerID , @DeveloperID , @Price ,@CompletionDate , @OrderDesc , @Requirements , GETDATE() , 'In Progress')



                        GO
                        /****** Object:  StoredProcedure [dbo].[InsertNewTask]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[InsertNewTask]
                        (
	                        @OrderID varchar(max) , @DeveloperID varchar(max), @Description varchar(max), @Title varchar(max), @Notes varchar(max)
                        )
                        AS
                        INSERT INTO TDeveloperTasks (OrderID , DeveloperID , Title , Description , Notes , Status)
                        values (@OrderID, @DeveloperID , @Title , @Description , @Notes , 'In Progress')
                        GO
                        /****** Object:  StoredProcedure [dbo].[SendMessage]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[SendMessage]
                        ( 
	                        @RoleDesc varchar(MAX) , @Email varchar(MAX) , @Title varchar(MAX) , @Description varchar(max) , @EmailTo varchar(MAX)
                        )
                        AS
                        DECLARE @ID VARCHAR(50)
                        DECLARE @FirstName VARCHAR(MAX)
                        DECLARE @LastName VARCHAR(MAX)

                        IF @RoleDesc = 'Customer'
	                        BEGIN
		                        SET @ID = (SELECT CustomerID FROM TCustomers WHERE Email = @EmailTo)
		                        SET @FirstName = (SELECT FirstName FROM TCustomers WHERE Email = @EmailTo)
		                        SET @LastName = (SELECT LastName FROM TCustomers WHERE Email = @EmailTo)
		                        INSERT INTO TCustomerInbox(CustomerID , FirstName , LastName, ChatMessage, MessageDate , Email , Title)
		                        VALUES (@ID , @FirstName , @LastName , @Description , GETDATE() , @Email , @Title)
	                        END

                        IF @RoleDesc = 'Developer'
	                        BEGIN
		                        SET @ID = (SELECT DeveloperID FROM TDevelopers WHERE Email = @EmailTo)
		                        SET @FirstName = (SELECT FirstName FROM TDevelopers WHERE Email = @EmailTo)
		                        SET @LastName = (SELECT LastName FROM TDevelopers WHERE Email = @EmailTo)
		                        INSERT INTO TDeveloperInbox(DeveloperID , FirstName , LastName, ChatMessage, MessageDate , Email , Title)
		                        VALUES (@ID , @FirstName , @LastName , @Description , GETDATE() , @Email , @Title)
	                        END

                        IF @RoleDesc = 'Resource Manager'
	                        BEGIN
		                        SET @ID = (SELECT ResourceManagerID FROM TResourceManagers WHERE Email = @EmailTo)
		                        SET @FirstName = (SELECT FirstName FROM TResourceManagers WHERE Email = @EmailTo)
		                        SET @LastName = (SELECT LastName FROM TResourceManagers WHERE Email = @EmailTo)
		                        INSERT INTO TRMInbox(ResourceManagerID , FirstName , LastName, ChatMessage, MessageDate , Email , Title)
		                        VALUES (@ID , @FirstName , @LastName , @Description , GETDATE() , @Email , @Title)
	                        END
                        GO
                        /****** Object:  StoredProcedure [dbo].[UpdateCustomerDeclined]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[UpdateCustomerDeclined]
                        (
	                        @CustomerPendingID varchar(50) 
                        )
                        AS

                        UPDATE TCustomerPending  set CPStatus = 'declined' WHERE CustomerPendingID = @CustomerPendingID








                        GO
                        /****** Object:  StoredProcedure [dbo].[UpdateCustomerInfo]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[UpdateCustomerInfo]
                        (
	                        @CustomerID varchar(50),@FirstName varchar(max), @LastName varchar(max) , @PhoneNumber varchar(max) , @Email varchar(max) 
                        )
                        AS

                        UPDATE TCustomers SET FirstName = @FirstName , LastName = @LastName , PhoneNumber = @PhoneNumber , Email = @Email where CustomerID = @CustomerID
                        GO
                        /****** Object:  StoredProcedure [dbo].[UpdateDeveloperInfo]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[UpdateDeveloperInfo]
                        (
	                        @DeveloperID varchar(50),@FirstName varchar(50), @LastName varchar(50) , @PhoneNumber varchar(50) , @Email varchar(50) , @Title varchar(50) ,@Skills varchar(500) , @PLanguages varchar(100) , @Education varchar(500) , @Certificates varchar(500) , @Description varchar(1000) 
                        )
                        AS

                        UPDATE TDevelopers SET FirstName = @FirstName , LastName = @LastName , PhoneNumber = @PhoneNumber , Email = @Email , Title = @Title , Skills = @Skills , PLanguages = @PLanguages , Education = @Education , Certification = @Certificates , Description = @Description where DeveloperID = @DeveloperID
                        GO
                        /****** Object:  StoredProcedure [dbo].[UpdateDeveloperNote]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[UpdateDeveloperNote]
                        (
	                         @DeveloperNoteID varchar(max) , @NoteContent VARCHAR(MAX)
                        )
                        AS

                        UPDATE TDeveloperNotes SET NoteContent = @NoteContent where DeveloperNoteID = @DeveloperNoteID

                        GO
                        /****** Object:  StoredProcedure [dbo].[UpdateDevGalleryPhoto]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[UpdateDevGalleryPhoto]
                        (
	                        @DeveloperProjectID varchar(50) , @Description varchar(max) , @Title varchar(max)
                        )
                        AS

                        UPDATE TDeveloperProjects SET Alt = @Description, Title = @Title WHERE DeveloperProjectID = @DeveloperProjectID
                        GO
                        /****** Object:  StoredProcedure [dbo].[UpdateDevLink]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[UpdateDevLink]
                        (
	                        @DeveloperLinkID varchar(max) , @Title varchar(max), @HyperLink varchar(max) , @ViewType varchar(max)
                        )
                        AS
                        UPDATE TDeveloperLinks SET Title = @Title , HyperLink = @HyperLink , ViewType = @ViewType where DeveloperLinkID = @DeveloperLinkID
                        GO
                        /****** Object:  StoredProcedure [dbo].[UpdateDevNote]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[UpdateDevNote]
                        (
	                         @DeveloperNoteID varchar(max) , @Title varchar(max) , @ViewType varchar(max)
                        )
                        AS

                        UPDATE TDeveloperNotes SET Title = @Title , ViewType = @ViewType WHERE DeveloperNoteID = @DeveloperNoteID


                        GO
                        /****** Object:  StoredProcedure [dbo].[UpdateDevOrderComplete]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[UpdateDevOrderComplete]
                        (
	                        @OrderID varchar(50)
                        )
                        AS
                        UPDATE TOrders SET Status = 'Developed' WHERE OrderID = @OrderID
                        GO
                        /****** Object:  StoredProcedure [dbo].[UpdateOrderAccepted_Dev]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[UpdateOrderAccepted_Dev]
                        (
	                        @DeveloperPendingID varchar(50) , @PriceOffered VARCHAR(MAX)  , @DateOffered VARCHAR(MAX)
                        )

                        AS

                        UPDATE TDeveloperPending SET DPStatus = 'replied' WHERE DeveloperPendingID = @DeveloperPendingID


                        DECLARE @CustomerID varchar(50)
                        DECLARE @DeveloperID varchar(50)
                        DECLARE @OrderDesc varchar(max)
                        DECLARE @Requirements varchar(max)

                        SET @CustomerID = (SELECT CustomerID FROM TDeveloperPending WHERE  DeveloperPendingID = @DeveloperPendingID)
                        SET @DeveloperID = (SELECT DeveloperID FROM TDeveloperPending WHERE  DeveloperPendingID = @DeveloperPendingID)
                        SET @OrderDesc = (SELECT OrderDesc FROM TDeveloperPending WHERE  DeveloperPendingID = @DeveloperPendingID)
                        SET @Requirements = (SELECT Requirements FROM TDeveloperPending WHERE  DeveloperPendingID = @DeveloperPendingID)

                        INSERT INTO TCustomerPending (CustomerID , DeveloperID , PriceOffered , DateOffered , OrderDesc , Requirements , CPStatus , DateCreated)
                        VALUES (@CustomerID , @DeveloperID , @PriceOffered , @DateOffered , @OrderDesc , @Requirements , 'unreplied' , GETDATE())



                        GO
                        /****** Object:  StoredProcedure [dbo].[UpdateOrderComplete]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[UpdateOrderComplete]
                        (
	                        @OrderID varchar(max) , @Review varchar(max), @Rating varchar(max)
                        )
                        AS
                        UPDATE TOrders SET CustomerReview = @Review , Rating = @Rating , Status = 'Complete' WHERE OrderID = @OrderID
                        GO
                        /****** Object:  StoredProcedure [dbo].[UpdateOrderDeclined]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[UpdateOrderDeclined]
                        (
	                        @DeveloperPendingID varchar(50) , @DeclineReason varchar(max)
                        )
                        AS

                        UPDATE TDeveloperPending  set DPStatus = 'declined' WHERE DeveloperPendingID = @DeveloperPendingID


                        DECLARE @DeveloperID INT 
                        DECLARE @OrderDesc VARCHAR(MAX)
                        SET @DeveloperID = (SELECT DeveloperID FROM TDeveloperPending where DeveloperPendingID = @DeveloperPendingID)
                        SET @OrderDesc = (SELECT OrderDesc FROM TDeveloperPending where DeveloperPendingID = @DeveloperPendingID)
                        INSERT INTO TDeveloperDeclined (DeveloperPendingID , DeveloperID , OrderDescription , DeclineReason , DeclinedDate)
                        VALUES  (@DeveloperPendingID , @DeveloperID , @OrderDesc , @DeclineReason , GETDATE())







                        GO
                        /****** Object:  StoredProcedure [dbo].[UpdatePhoto]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[UpdatePhoto]
                        (
	                        @Email varchar(max), @NewPhoto varchar(max) , @Role varchar(max)
                        )
                        AS
                        If @Role = 'Developer' 
	                        Begin
	                        UPDATE TDevelopers SET Photo = @NewPhoto WHERE Email = @Email
	                        END
                        If @Role = 'Customer' 
	                        Begin
	                        UPDATE TCustomers SET Photo = @NewPhoto WHERE Email = @Email	
	                        END
                        If @Role = 'ResourceManager' 
	                        Begin
	                        UPDATE TResourceManagers SET Photo = @NewPhoto WHERE Email = @Email	
	                        END

                        GO
                        /****** Object:  StoredProcedure [dbo].[UpdateResetPassword]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[UpdateResetPassword]
                        (
	                        @Email varchar(max), @Password varchar(max)
                        )
                        AS

                        IF (SELECT count(*) from TCustomers where Email = @Email) > 0
	                        BEGIN
	                        UPDATE TCustomers set  Password = @Password WHERE Email  = @Email
	                        END

                        IF (SELECT count(*) from TDevelopers where Email = @Email) > 0
	                        BEGIN
	                        UPDATE TDevelopers set  Password = @Password WHERE Email  = @Email
	                        END

                        IF (SELECT count(*) from TResourceManagers where Email = @Email) > 0
	                        BEGIN
	                        UPDATE TResourceManagers set  Password = @Password WHERE Email  = @Email
	                        END
                        GO
                        /****** Object:  StoredProcedure [dbo].[UpdateResourceManagerNote]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[UpdateResourceManagerNote]
                        (
	                         @ResourceManagerNotesID varchar(max) , @NoteContent VARCHAR(MAX)
                        )
                        AS

                        UPDATE TResourceManagerNotes SET NoteContent = @NoteContent where ResourceManagerNotesID = @ResourceManagerNotesID

                        GO
                        /****** Object:  StoredProcedure [dbo].[UpdateRMInfo]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[UpdateRMInfo]
                        (
	                        @ResourceManagerID varchar(50),@FirstName varchar(max), @LastName varchar(max) , @PhoneNumber varchar(max) , @Email varchar(max) 
                        )
                        AS

                        UPDATE TResourceManagers SET FirstName = @FirstName , LastName = @LastName , PhoneNumber = @PhoneNumber , Email = @Email where ResourceManagerID = @ResourceManagerID
                        GO
                        /****** Object:  StoredProcedure [dbo].[UpdateRMLink]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[UpdateRMLink]
                        (
	                        @ResourceManagerLinkID varchar(max) , @Title varchar(max), @HyperLink varchar(max) , @ViewType varchar(max)
                        )
                        AS
                        UPDATE TResourceManagerLinks SET Title = @Title , HyperLink = @HyperLink , ViewType = @ViewType where ResourceManagerLinkID = @ResourceManagerLinkID
                        GO
                        /****** Object:  StoredProcedure [dbo].[UpdateRMNote]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[UpdateRMNote]
                        (
	                         @ResourceManagerNotesID varchar(max) , @Title varchar(max) , @ViewType varchar(max)
                        )
                        AS

                        UPDATE TResourceManagerNotes SET Title = @Title , ViewType = @ViewType WHERE ResourceManagerNotesID = @ResourceManagerNotesID


                        GO
                        /****** Object:  StoredProcedure [dbo].[UpdateRMOpenOrder]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[UpdateRMOpenOrder]
                        (
	                        @OrderID varchar(max) , @NewPrice varchar(max), @DateBy varchar(max) , @Requirements varchar(max)
                        )
                        AS
                        UPDATE TOrders SET Price = @NewPrice , CompletionDate = @DateBy , Requirements = @Requirements WHERE OrderID = @OrderID
                        GO
                        /****** Object:  StoredProcedure [dbo].[UpdateTask]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[UpdateTask]
                        (
	                        @DeveloperTaskID varchar(max) , @Title varchar(max), @Description varchar(max),  @Notes varchar(max) , @Status varchar(max)
                        )
                        AS
                        UPDATE TDeveloperTasks SET Title = @Title , Description = @Description , Notes = @Notes , Status = @Status WHERE DeveloperTaskID = @DeveloperTaskID
                        GO
                        /****** Object:  StoredProcedure [dbo].[UpdateUserDashboardColor]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[UpdateUserDashboardColor]
                        (
	                        @UserID varchar(max) , @UserRoleDesc varchar(max), @DashboardColor varchar(max)
                        )
                        AS
                        IF @UserRoleDesc = 'Customer' OR @UserRoleDesc = 'customer'
	                        BEGIN
	                        UPDATE TCustomers SET DashboardColor = @DashboardColor WHERE CustomerID = @UserID
	                        END
                        IF @UserRoleDesc = 'Developer' OR @UserRoleDesc = 'developer'
	                        BEGIN
	                        UPDATE TDevelopers SET DashboardColor = @DashboardColor WHERE DeveloperID = @UserID
	                        END
                        IF @UserRoleDesc = 'ResourceManager' OR @UserRoleDesc = 'resourcemanager'
	                        BEGIN
	                        UPDATE TResourceManagers SET DashboardColor = @DashboardColor WHERE ResourceManagerID = @UserID
	                        END
                        GO
                        /****** Object:  StoredProcedure [dbo].[UpdateUserSideBarColor]    Script Date: 4/21/2021 2:37:23 AM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO

                        CREATE PROCEDURE [dbo].[UpdateUserSideBarColor]
                        (
	                        @UserID varchar(max) , @UserRoleDesc varchar(max), @SideBarColor varchar(max)
                        )
                        AS
                        IF @UserRoleDesc = 'Customer' OR @UserRoleDesc = 'customer'
	                        BEGIN
	                        UPDATE TCustomers SET SideBarColor = @SideBarColor WHERE CustomerID = @UserID
	                        END
                        IF @UserRoleDesc = 'Developer' OR @UserRoleDesc = 'developer'
	                        BEGIN
	                        UPDATE TDevelopers SET SideBarColor = @SideBarColor WHERE DeveloperID = @UserID
	                        END
                        IF @UserRoleDesc = 'ResourceManager' OR @UserRoleDesc = 'resourcemanager'
	                        BEGIN
	                        UPDATE TResourceManagers SET SideBarColor = @SideBarColor WHERE ResourceManagerID = @UserID
	                        END
                        GO
                        "
                );
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TCustomerInbox");

            migrationBuilder.DropTable(
                name: "TCustomerPending");

            migrationBuilder.DropTable(
                name: "TCustomers");

            migrationBuilder.DropTable(
                name: "TDeveloperDeclined");

            migrationBuilder.DropTable(
                name: "TDeveloperInbox");

            migrationBuilder.DropTable(
                name: "TDeveloperLinks");

            migrationBuilder.DropTable(
                name: "TDeveloperNotes");

            migrationBuilder.DropTable(
                name: "TDeveloperPending");

            migrationBuilder.DropTable(
                name: "TDeveloperProjects");

            migrationBuilder.DropTable(
                name: "TDevelopers");

            migrationBuilder.DropTable(
                name: "TDeveloperTasks");

            migrationBuilder.DropTable(
                name: "TOrders");

            migrationBuilder.DropTable(
                name: "TResourceManagerLinks");

            migrationBuilder.DropTable(
                name: "TResourceManagerNotes");

            migrationBuilder.DropTable(
                name: "TResourceManagers");

            migrationBuilder.DropTable(
                name: "TRMDeveloper");

            migrationBuilder.DropTable(
                name: "TRMInbox");

            migrationBuilder.DropTable(
                name: "TRoles");
        }
    }
}
