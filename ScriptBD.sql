USE [DBAseguraYADemo];
GO

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'686DP_Cliente')
    EXEC('CREATE SCHEMA [686DP_Cliente]');
GO

PRINT 'Creando tablas...';
GO

/****** Object:  Table [686DP_Cliente].[686DP_Clienctes_C]    Script Date: 10/27/2025 9:41:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [686DP_Cliente].[686DP_Clienctes_C](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DP686_Estado] [bit] NULL,
	[DP686_DNI] [int] NOT NULL,
	[DP686_Nombre] [varchar](100) NOT NULL,
	[DP686_Apellido] [varchar](100) NOT NULL,
	[DP686_Email] [varchar](100) NULL,
	[DP686_Domicilio] [varchar](100) NULL,
	[DP686DP_CodigoPostal] [int] NULL,
	[DP686_Fecha] [datetime] NOT NULL,
	[DP686_Activo] [bit] NOT NULL,
 CONSTRAINT [PK_686DP_Clienctes_C] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [686DP_Cliente].[686DP_Clientes]    Script Date: 10/27/2025 9:41:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [686DP_Cliente].[686DP_Clientes](
	[DP686_DNI] [int] NOT NULL,
	[DP686_Nombre] [varchar](100) NOT NULL,
	[DP686_Apellido] [varchar](100) NOT NULL,
	[DP686_Email] [varchar](100) NULL,
	[DP686_Domicilio] [varchar](100) NULL,
	[DP686DP_CodigoPostal] [int] NULL,
	[DP686_Estado] [bit] NULL,
 CONSTRAINT [PK_686DP_Clientes] PRIMARY KEY CLUSTERED 
(
	[DP686_DNI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[686DP UsuarioContraseñas]    Script Date: 10/27/2025 9:41:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[686DP UsuarioContraseñas](
	[DP686_DNI] [int] NOT NULL,
	[DP686_Contraseña] [varchar](256) NOT NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[686DP_Cobertura]    Script Date: 10/27/2025 9:41:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[686DP_Cobertura](
	[DP686_Descripcion] [varchar](100) NOT NULL,
	[DP686_SumaAsegurada] [money] NOT NULL,
	[CodigoCobertura] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_686DP_Cobertura] PRIMARY KEY CLUSTERED 
(
	[CodigoCobertura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[686DP_DigitoVerificador]    Script Date: 10/27/2025 9:41:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[686DP_DigitoVerificador](
	[DP686NombreTabla] [varchar](50) NOT NULL,
	[DP686DVH] [varchar](200) NOT NULL,
	[DP686DVV] [varchar](200) NOT NULL,
 CONSTRAINT [PK_686DP_DigitoVerificador] PRIMARY KEY CLUSTERED 
(
	[DP686NombreTabla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[686DP_Eventos]    Script Date: 10/27/2025 9:41:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[686DP_Eventos](
	[DP686_DNI] [int] NOT NULL,
	[DP686_CodEvento] [varchar](100) NOT NULL,
	[DP686_Fecha] [date] NOT NULL,
	[DP686_Modulo] [varchar](100) NOT NULL,
	[DP686_Descripcion] [varchar](100) NOT NULL,
	[DP686_Criticidad] [int] NOT NULL,
 CONSTRAINT [PK_686DP_Eventos] PRIMARY KEY CLUSTERED 
(
	[DP686_CodEvento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[686DP_Factura]    Script Date: 10/27/2025 9:41:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[686DP_Factura](
	[CodFactura] [int] IDENTITY(1,1) NOT NULL,
	[CodSiniestro] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_686DP_Factura] PRIMARY KEY CLUSTERED 
(
	[CodFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[686DP_Familia]    Script Date: 10/27/2025 9:41:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[686DP_Familia](
	[DP686_FamiliaID] [int] IDENTITY(1,1) NOT NULL,
	[DP686_Nombre] [varchar](100) NOT NULL,
	[DP686_Profundidad] [bit] NOT NULL,
 CONSTRAINT [PK_686DP_Familia] PRIMARY KEY CLUSTERED 
(
	[DP686_FamiliaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[686DP_FamiliaPermiso]    Script Date: 10/27/2025 9:41:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[686DP_FamiliaPermiso](
	[DP686_FamiliaID] [int] NOT NULL,
	[DP686_PermisoID] [int] NOT NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[686DP_Perfil]    Script Date: 10/27/2025 9:41:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[686DP_Perfil](
	[DP686_PerfilID] [int] IDENTITY(1,1) NOT NULL,
	[DP686_Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_686DP_Perfil] PRIMARY KEY CLUSTERED 
(
	[DP686_PerfilID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[686DP_PerfilFamilia]    Script Date: 10/27/2025 9:41:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[686DP_PerfilFamilia](
	[DP686_FamiliaID] [int] NOT NULL,
	[DP686_PerfilID] [int] NOT NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[686DP_PerfilPermiso]    Script Date: 10/27/2025 9:41:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[686DP_PerfilPermiso](
	[DP686_PerfilID] [int] NOT NULL,
	[DP686_PermisoID] [int] NOT NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[686DP_PermisoSimple]    Script Date: 10/27/2025 9:41:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[686DP_PermisoSimple](
	[DP686_PermisoID] [int] IDENTITY(1,1) NOT NULL,
	[DP686_Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_686DP_PermisoSimple] PRIMARY KEY CLUSTERED 
(
	[DP686_PermisoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[686DP_Plan]    Script Date: 10/27/2025 9:41:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[686DP_Plan](
	[DP686_CodigoPlan] [int] IDENTITY(1,1) NOT NULL,
	[DP686_Franquicia] [money] NOT NULL,
	[DP686_Prima] [money] NOT NULL,
 CONSTRAINT [PK_686DP_Plan] PRIMARY KEY CLUSTERED 
(
	[DP686_CodigoPlan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[686DP_PlanesCoberturas]    Script Date: 10/27/2025 9:41:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[686DP_PlanesCoberturas](
	[DP686_CodigoPlan] [int] NOT NULL,
	[CodigoCobertura] [int] NOT NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[686DP_Poliza]    Script Date: 10/27/2025 9:41:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[686DP_Poliza](
	[DP686_NPoliza] [int] IDENTITY(1,1) NOT NULL,
	[DP686_Estado] [bit] NOT NULL,
	[DP686_valorTotal] [money] NOT NULL,
	[DP686_FechaVencimiento] [datetime] NOT NULL,
	[DP686_Endoso] [int] NOT NULL,
	[DP686_CodSeguro] [int] NOT NULL,
	[DP686_CodPlan] [int] NOT NULL,
 CONSTRAINT [PK_686DP_Poliza] PRIMARY KEY CLUSTERED 
(
	[DP686_NPoliza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[686DP_PolizaSeguro]    Script Date: 10/27/2025 9:41:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[686DP_PolizaSeguro](
	[DP686_NPoliza] [int] NOT NULL,
	[DP686_CodSeguro] [int] NOT NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[686DP_PolizaSiniestro]    Script Date: 10/27/2025 9:41:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[686DP_PolizaSiniestro](
	[CodSiniestro] [int] NOT NULL,
	[DP686_NPoliza] [int] NOT NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[686DP_Seguro]    Script Date: 10/27/2025 9:41:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[686DP_Seguro](
	[DP686_CodSeguro] [int] IDENTITY(1,1) NOT NULL,
	[DP686_ProductoNombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_686DP_Seguro] PRIMARY KEY CLUSTERED 
(
	[DP686_CodSeguro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[686DP_SeguroPlan]    Script Date: 10/27/2025 9:41:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[686DP_SeguroPlan](
	[DP686_CodSeguro] [int] NOT NULL,
	[DP686_CodigoPlan] [int] NOT NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[686DP_Siniestro]    Script Date: 10/27/2025 9:41:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[686DP_Siniestro](
	[CodSiniestro] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Valor] [money] NULL,
	[ValorDeReparacion] [money] NOT NULL,
	[ValorDelBien] [money] NOT NULL,
	[Estado] [bit] NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
 CONSTRAINT [PK_686DP_Siniestro] PRIMARY KEY CLUSTERED 
(
	[CodSiniestro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[686DP_Usuario]    Script Date: 10/27/2025 9:41:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[686DP_Usuario](
	[DP686_DNI] [int] NOT NULL,
	[DP686_Nombre] [varchar](100) NOT NULL,
	[DP686_Apellido] [varchar](100) NOT NULL,
	[DP686_Email] [varchar](100) NOT NULL,
	[DP686_Usuario] [varchar](100) NOT NULL,
	[DP686_Contraseña] [varchar](256) NOT NULL,
	[DP686_Activo] [bit] NOT NULL,
	[DP686_Bloqueado] [bit] NOT NULL,
	[DP686_CambiarContraseña] [bit] NOT NULL,
	[DP686_PerfilID] [int] NOT NULL,
	[DP686_Idioma] [varchar](100) NOT NULL,
 CONSTRAINT [PK_686DP_Empleado] PRIMARY KEY CLUSTERED 
(
	[DP686_DNI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[686DP_UsuarioIntentos]    Script Date: 10/27/2025 9:41:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[686DP_UsuarioIntentos](
	[DP686_DNI] [int] NOT NULL,
	[DP686_intentos] [tinyint] NOT NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[686DPClientePoliza]    Script Date: 10/27/2025 9:41:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[686DPClientePoliza](
	[DP686_NPoliza] [int] NOT NULL,
	[DP686_DNICliente] [int] NOT NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[686DPPolizaCancelacion]    Script Date: 10/27/2025 9:41:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[686DPPolizaCancelacion](
	[DP686_NPoliza] [int] NOT NULL,
	[Motivo] [varchar](100) NOT NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[686FP_FamiliaFamilia]    Script Date: 10/27/2025 9:41:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[686FP_FamiliaFamilia](
	[DP686_FamiliaPadre] [int] NOT NULL,
	[DP686_Componentes] [int] NOT NULL
) ON [PRIMARY]
GO

PRINT 'Creando claves primarias y foráneas...';
GO

ALTER TABLE [686DP_Cliente].[686DP_Clienctes_C] ADD  CONSTRAINT [DF_686DP_Clienctes_C_DP686_Estado]  DEFAULT ((1)) FOR [DP686_Estado]
GO

ALTER TABLE [686DP_Cliente].[686DP_Clientes] ADD  CONSTRAINT [DF_686DP_Clientes_DP686_Estado]  DEFAULT ((1)) FOR [DP686_Estado]
GO

ALTER TABLE [dbo].[686DP_Familia] ADD  CONSTRAINT [DF_686DP_Familia_DP686_Profundidad]  DEFAULT ((0)) FOR [DP686_Profundidad]
GO

ALTER TABLE [dbo].[686DP_Poliza] ADD  CONSTRAINT [DF_686DP_Poliza_DP686_Estado]  DEFAULT ((1)) FOR [DP686_Estado]
GO

ALTER TABLE [dbo].[686DP_Usuario] ADD  CONSTRAINT [DF_686DP_Empleado_DP686_Activo]  DEFAULT ((1)) FOR [DP686_Activo]
GO

ALTER TABLE [dbo].[686DP_Usuario] ADD  CONSTRAINT [DF_686DP_Empleado_DP686_Bloqueado]  DEFAULT ((0)) FOR [DP686_Bloqueado]
GO

ALTER TABLE [dbo].[686DP_Usuario] ADD  CONSTRAINT [DF_686DP_Usuario_DP686_Idioma]  DEFAULT ('Español') FOR [DP686_Idioma]
GO

ALTER TABLE [686DP_Cliente].[686DP_Clienctes_C]  WITH CHECK ADD  CONSTRAINT [FK_686DP_Clienctes_C_686DP_Clientes] FOREIGN KEY([DP686_DNI])
REFERENCES [686DP_Cliente].[686DP_Clientes] ([DP686_DNI])
GO

ALTER TABLE [686DP_Cliente].[686DP_Clienctes_C] CHECK CONSTRAINT [FK_686DP_Clienctes_C_686DP_Clientes]
GO

ALTER TABLE [dbo].[686DP UsuarioContraseñas]  WITH CHECK ADD  CONSTRAINT [FK_686DP EmpleadoContraseñas_686DP_Empleado] FOREIGN KEY([DP686_DNI])
REFERENCES [dbo].[686DP_Usuario] ([DP686_DNI])
GO

ALTER TABLE [dbo].[686DP UsuarioContraseñas] CHECK CONSTRAINT [FK_686DP EmpleadoContraseñas_686DP_Empleado]
GO

ALTER TABLE [dbo].[686DP_Eventos]  WITH CHECK ADD  CONSTRAINT [FK_686DP_Eventos_686DP_Usuario] FOREIGN KEY([DP686_DNI])
REFERENCES [dbo].[686DP_Usuario] ([DP686_DNI])
GO

ALTER TABLE [dbo].[686DP_Eventos] CHECK CONSTRAINT [FK_686DP_Eventos_686DP_Usuario]
GO

ALTER TABLE [dbo].[686DP_Factura]  WITH CHECK ADD  CONSTRAINT [FK_686DP_Factura_686DP_Siniestro] FOREIGN KEY([CodSiniestro])
REFERENCES [dbo].[686DP_Siniestro] ([CodSiniestro])
GO

ALTER TABLE [dbo].[686DP_Factura] CHECK CONSTRAINT [FK_686DP_Factura_686DP_Siniestro]
GO

ALTER TABLE [dbo].[686DP_FamiliaPermiso]  WITH CHECK ADD  CONSTRAINT [FK_686DP_FamiliaPermiso_686DP_Familia] FOREIGN KEY([DP686_FamiliaID])
REFERENCES [dbo].[686DP_Familia] ([DP686_FamiliaID])
GO

ALTER TABLE [dbo].[686DP_FamiliaPermiso] CHECK CONSTRAINT [FK_686DP_FamiliaPermiso_686DP_Familia]
GO

ALTER TABLE [dbo].[686DP_FamiliaPermiso]  WITH CHECK ADD  CONSTRAINT [FK_686DP_FamiliaPermiso_686DP_PermisoSimple] FOREIGN KEY([DP686_PermisoID])
REFERENCES [dbo].[686DP_PermisoSimple] ([DP686_PermisoID])
GO

ALTER TABLE [dbo].[686DP_FamiliaPermiso] CHECK CONSTRAINT [FK_686DP_FamiliaPermiso_686DP_PermisoSimple]
GO

ALTER TABLE [dbo].[686DP_PerfilFamilia]  WITH CHECK ADD  CONSTRAINT [FK_686DP_PerfilFamilia_686DP_Familia] FOREIGN KEY([DP686_FamiliaID])
REFERENCES [dbo].[686DP_Familia] ([DP686_FamiliaID])
GO

ALTER TABLE [dbo].[686DP_PerfilFamilia] CHECK CONSTRAINT [FK_686DP_PerfilFamilia_686DP_Familia]
GO

ALTER TABLE [dbo].[686DP_PerfilFamilia]  WITH CHECK ADD  CONSTRAINT [FK_686DP_PerfilFamilia_686DP_Perfil] FOREIGN KEY([DP686_PerfilID])
REFERENCES [dbo].[686DP_Perfil] ([DP686_PerfilID])
GO

ALTER TABLE [dbo].[686DP_PerfilFamilia] CHECK CONSTRAINT [FK_686DP_PerfilFamilia_686DP_Perfil]
GO

ALTER TABLE [dbo].[686DP_PerfilPermiso]  WITH CHECK ADD  CONSTRAINT [FK_686DP_PerfilPermiso_686DP_Perfil] FOREIGN KEY([DP686_PerfilID])
REFERENCES [dbo].[686DP_Perfil] ([DP686_PerfilID])
GO

ALTER TABLE [dbo].[686DP_PerfilPermiso] CHECK CONSTRAINT [FK_686DP_PerfilPermiso_686DP_Perfil]
GO

ALTER TABLE [dbo].[686DP_PerfilPermiso]  WITH CHECK ADD  CONSTRAINT [FK_686DP_PerfilPermiso_686DP_PermisoSimple] FOREIGN KEY([DP686_PermisoID])
REFERENCES [dbo].[686DP_PermisoSimple] ([DP686_PermisoID])
GO

ALTER TABLE [dbo].[686DP_PerfilPermiso] CHECK CONSTRAINT [FK_686DP_PerfilPermiso_686DP_PermisoSimple]
GO

ALTER TABLE [dbo].[686DP_PlanesCoberturas]  WITH CHECK ADD  CONSTRAINT [FK_686DP_PlanesCoberturas_686DP_Cobertura] FOREIGN KEY([CodigoCobertura])
REFERENCES [dbo].[686DP_Cobertura] ([CodigoCobertura])
GO

ALTER TABLE [dbo].[686DP_PlanesCoberturas] CHECK CONSTRAINT [FK_686DP_PlanesCoberturas_686DP_Cobertura]
GO

ALTER TABLE [dbo].[686DP_PlanesCoberturas]  WITH CHECK ADD  CONSTRAINT [FK_686DP_PlanesCoberturas_686DP_Plan] FOREIGN KEY([DP686_CodigoPlan])
REFERENCES [dbo].[686DP_Plan] ([DP686_CodigoPlan])
GO

ALTER TABLE [dbo].[686DP_PlanesCoberturas] CHECK CONSTRAINT [FK_686DP_PlanesCoberturas_686DP_Plan]
GO

ALTER TABLE [dbo].[686DP_Poliza]  WITH CHECK ADD  CONSTRAINT [FK_686DP_Poliza_686DP_Plan] FOREIGN KEY([DP686_CodPlan])
REFERENCES [dbo].[686DP_Plan] ([DP686_CodigoPlan])
GO

ALTER TABLE [dbo].[686DP_Poliza] CHECK CONSTRAINT [FK_686DP_Poliza_686DP_Plan]
GO

ALTER TABLE [dbo].[686DP_Poliza]  WITH CHECK ADD  CONSTRAINT [FK_686DP_Poliza_686DP_Seguro] FOREIGN KEY([DP686_CodSeguro])
REFERENCES [dbo].[686DP_Seguro] ([DP686_CodSeguro])
GO

ALTER TABLE [dbo].[686DP_Poliza] CHECK CONSTRAINT [FK_686DP_Poliza_686DP_Seguro]
GO

ALTER TABLE [dbo].[686DP_PolizaSeguro]  WITH CHECK ADD  CONSTRAINT [FK_686DP_PolizaSeguro_686DP_Poliza] FOREIGN KEY([DP686_NPoliza])
REFERENCES [dbo].[686DP_Poliza] ([DP686_NPoliza])
GO

ALTER TABLE [dbo].[686DP_PolizaSeguro] CHECK CONSTRAINT [FK_686DP_PolizaSeguro_686DP_Poliza]
GO

ALTER TABLE [dbo].[686DP_PolizaSeguro]  WITH CHECK ADD  CONSTRAINT [FK_686DP_PolizaSeguro_686DP_Seguro] FOREIGN KEY([DP686_CodSeguro])
REFERENCES [dbo].[686DP_Seguro] ([DP686_CodSeguro])
GO

ALTER TABLE [dbo].[686DP_PolizaSeguro] CHECK CONSTRAINT [FK_686DP_PolizaSeguro_686DP_Seguro]
GO

ALTER TABLE [dbo].[686DP_PolizaSiniestro]  WITH CHECK ADD  CONSTRAINT [FK_686DP_PolizaSiniestro_686DP_Poliza] FOREIGN KEY([DP686_NPoliza])
REFERENCES [dbo].[686DP_Poliza] ([DP686_NPoliza])
GO

ALTER TABLE [dbo].[686DP_PolizaSiniestro] CHECK CONSTRAINT [FK_686DP_PolizaSiniestro_686DP_Poliza]
GO

ALTER TABLE [dbo].[686DP_PolizaSiniestro]  WITH CHECK ADD  CONSTRAINT [FK_686DP_PolizaSiniestro_686DP_Siniestro] FOREIGN KEY([CodSiniestro])
REFERENCES [dbo].[686DP_Siniestro] ([CodSiniestro])
GO

ALTER TABLE [dbo].[686DP_PolizaSiniestro] CHECK CONSTRAINT [FK_686DP_PolizaSiniestro_686DP_Siniestro]
GO

ALTER TABLE [dbo].[686DP_SeguroPlan]  WITH CHECK ADD  CONSTRAINT [FK_686DP_SeguroPlan_686DP_Plan] FOREIGN KEY([DP686_CodigoPlan])
REFERENCES [dbo].[686DP_Plan] ([DP686_CodigoPlan])
GO

ALTER TABLE [dbo].[686DP_SeguroPlan] CHECK CONSTRAINT [FK_686DP_SeguroPlan_686DP_Plan]
GO

ALTER TABLE [dbo].[686DP_SeguroPlan]  WITH CHECK ADD  CONSTRAINT [FK_686DP_SeguroPlan_686DP_Seguro] FOREIGN KEY([DP686_CodSeguro])
REFERENCES [dbo].[686DP_Seguro] ([DP686_CodSeguro])
GO

ALTER TABLE [dbo].[686DP_SeguroPlan] CHECK CONSTRAINT [FK_686DP_SeguroPlan_686DP_Seguro]
GO

ALTER TABLE [dbo].[686DP_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_686DP_Usuario_686DP_Perfil] FOREIGN KEY([DP686_PerfilID])
REFERENCES [dbo].[686DP_Perfil] ([DP686_PerfilID])
GO

ALTER TABLE [dbo].[686DP_Usuario] CHECK CONSTRAINT [FK_686DP_Usuario_686DP_Perfil]
GO

ALTER TABLE [dbo].[686DP_UsuarioIntentos]  WITH CHECK ADD  CONSTRAINT [FK_686DP_EmpleadoIntentos_686DP_Empleado] FOREIGN KEY([DP686_DNI])
REFERENCES [dbo].[686DP_Usuario] ([DP686_DNI])
GO

ALTER TABLE [dbo].[686DP_UsuarioIntentos] CHECK CONSTRAINT [FK_686DP_EmpleadoIntentos_686DP_Empleado]
GO

ALTER TABLE [dbo].[686DPClientePoliza]  WITH CHECK ADD  CONSTRAINT [FK_686DPClientePoliza_686DP_Clientes] FOREIGN KEY([DP686_DNICliente])
REFERENCES [686DP_Cliente].[686DP_Clientes] ([DP686_DNI])
GO

ALTER TABLE [dbo].[686DPClientePoliza] CHECK CONSTRAINT [FK_686DPClientePoliza_686DP_Clientes]
GO

ALTER TABLE [dbo].[686DPClientePoliza]  WITH CHECK ADD  CONSTRAINT [FK_686DPClientePoliza_686DP_Poliza] FOREIGN KEY([DP686_NPoliza])
REFERENCES [dbo].[686DP_Poliza] ([DP686_NPoliza])
GO

ALTER TABLE [dbo].[686DPClientePoliza] CHECK CONSTRAINT [FK_686DPClientePoliza_686DP_Poliza]
GO

ALTER TABLE [dbo].[686DPPolizaCancelacion]  WITH CHECK ADD  CONSTRAINT [FK_686DPPolizaCancelacion_686DP_Poliza] FOREIGN KEY([DP686_NPoliza])
REFERENCES [dbo].[686DP_Poliza] ([DP686_NPoliza])
GO

ALTER TABLE [dbo].[686DPPolizaCancelacion] CHECK CONSTRAINT [FK_686DPPolizaCancelacion_686DP_Poliza]
GO

ALTER TABLE [dbo].[686FP_FamiliaFamilia]  WITH CHECK ADD  CONSTRAINT [FK_686FP_FamiliaFamilia_686DP_Familia] FOREIGN KEY([DP686_FamiliaPadre])
REFERENCES [dbo].[686DP_Familia] ([DP686_FamiliaID])
GO

ALTER TABLE [dbo].[686FP_FamiliaFamilia] CHECK CONSTRAINT [FK_686FP_FamiliaFamilia_686DP_Familia]
GO

PRINT 'Creando stored procedures...';
GO

GO
/****** Object:  Trigger [686DP_Cliente].[_686DP_ClienteActualizado]    Script Date: 27/10/2025 09:50:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create TRIGGER [686DP_Cliente].[_686DP_ClienteActualizado]
ON [686DP_Cliente].[686DP_Clientes]
AFTER INSERT, UPDATE
AS
BEGIN
    -- Evitar ejecuciones anidadas
    IF (TRIGGER_NESTLEVEL() > 1)
        RETURN;

    -- Desactivar los registros previos del cliente en la tabla de cambios
    UPDATE [686DP_Cliente].[686DP_Clienctes_C]
    SET [DP686_Activo] = 0
    WHERE [DP686_DNI] IN (SELECT [DP686_DNI] FROM inserted);

    -- Insertar el nuevo registro con los datos actualizados
    INSERT INTO [686DP_Cliente].[686DP_Clienctes_C]
        (DP686_Estado, DP686_DNI, DP686_Nombre, DP686_Apellido, 
        DP686_Email, DP686_Domicilio, DP686DP_CodigoPostal,
		DP686_Fecha, DP686_Activo)
    SELECT 
        DP686_Estado, DP686_DNI, DP686_Nombre, DP686_Apellido, 
        DP686_Email, DP686_Domicilio, DP686DP_CodigoPostal, 
        GETDATE(), 1
    FROM inserted;
END


GO

/****** Object:  StoredProcedure [686DP_Cliente].[spInsertarCliente_686DP]    Script Date: 10/27/2025 9:41:57 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [686DP_Cliente].[spInsertarCliente_686DP]
    @DNI INT,
    @Nombre VARCHAR(100),
    @Apellido VARCHAR(100),
    @Email VARCHAR(256) = NULL,
    @Domicilio VARCHAR(200) = NULL,
    @CodigoPostal INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [686DP_Cliente].[686DP_Clientes]
    SET
        DP686_Nombre = ISNULL(@Nombre, DP686_Nombre),
        DP686_Apellido = ISNULL(@Apellido, DP686_Apellido),
        DP686_Email = ISNULL(@Email, DP686_Email),
        DP686_Domicilio = ISNULL(@Domicilio, DP686_Domicilio),
        DP686DP_CodigoPostal = ISNULL(@CodigoPostal, DP686DP_CodigoPostal),
        DP686_Estado = 1
    WHERE DP686_DNI = @DNI;
END
GO

/****** Object:  StoredProcedure [dbo].[up686DP_InsertOrUpdateUsuario]    Script Date: 10/27/2025 9:41:57 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[up686DP_InsertOrUpdateUsuario]
    @DNI INT,
    @Nombre VARCHAR(100),
    @Apellido VARCHAR(100),
    @Email VARCHAR(100),
    @Usuario VARCHAR(100),
    @Contraseña NVARCHAR(256),
	@Rol  VARCHAR(100),
    @Activo BIT,
    @Bloqueado BIT,
    @Contra BIT,
	@Idioma VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @PerfilID INT;

    SELECT @PerfilID = [DP686_PerfilID]
    FROM [dbo].[686DP_Perfil]
    WHERE [DP686_Nombre] = @Rol;

    IF @PerfilID IS NULL
    BEGIN
        RAISERROR('Perfil no encontrado.', 16, 1);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM [dbo].[686DP_Usuario] WHERE [DP686_DNI] = @DNI)
    BEGIN
        UPDATE [dbo].[686DP_Usuario]
        SET 
            [DP686_Nombre] = @Nombre,
            [DP686_Apellido] = @Apellido,
            [DP686_Email] = @Email,
            [DP686_Usuario] = @Usuario,
            [DP686_Contraseña] = @Contraseña,
            [DP686_Activo] = @Activo,
            [DP686_Bloqueado] = @Bloqueado,
            [DP686_CambiarContraseña] = @Contra,
            [DP686_PerfilID] = @PerfilID,
			[DP686_Idioma] = @Idioma
        WHERE [DP686_DNI]= @DNI;
    END
    ELSE
    BEGIN
        INSERT INTO [dbo].[686DP_Usuario] (
            [DP686_DNI], [DP686_Nombre], [DP686_Apellido], [DP686_Email], [DP686_Usuario], [DP686_Contraseña],
            [DP686_Activo], [DP686_Bloqueado], [DP686_CambiarContraseña],
            [DP686_PerfilID], [DP686_Idioma]
        )
        VALUES (
            @DNI, @Nombre, @Apellido, @Email,
            @Usuario, @Contraseña,
            @Activo, @Bloqueado, @Contra,
            @PerfilID, @Idioma
        );
    END
END;
GO

/****** Object:  StoredProcedure [dbo].[upEvaluarYActualizarSiniestros_686DP]    Script Date: 10/27/2025 9:41:57 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[upEvaluarYActualizarSiniestros_686DP]
AS
BEGIN
    SET NOCOUNT ON;

    ------------------------------------------------------------
    -- 1️⃣ Actualiza el campo Valor en base a las condiciones
    ------------------------------------------------------------
    UPDATE sini
    SET sini.Valor =
        CASE 
            -- Califica normalmente
            WHEN (
                (
                    CASE 
                        WHEN sini.ValorDelBien < sini.ValorDeReparacion 
                            THEN sini.ValorDelBien 
                        ELSE sini.ValorDeReparacion 
                    END
                ) > pl.DP686_Franquicia
                AND
                (
                    CASE 
                        WHEN sini.ValorDelBien < sini.ValorDeReparacion 
                            THEN sini.ValorDelBien 
                        ELSE sini.ValorDeReparacion 
                    END
                ) <= c.DP686_SumaAsegurada
            )
            THEN 
                (
                    CASE 
                        WHEN sini.ValorDelBien < sini.ValorDeReparacion 
                            THEN sini.ValorDelBien 
                        ELSE sini.ValorDeReparacion 
                    END
                )

            -- Compensa hasta el tope de la suma asegurada
            WHEN (
                sini.ValorDelBien > c.DP686_SumaAsegurada 
                AND sini.ValorDeReparacion > c.DP686_SumaAsegurada
            )
            THEN c.DP686_SumaAsegurada

            -- No califica
            ELSE 0
        END
    FROM [dbo].[686DP_Siniestro] AS sini
    INNER JOIN [dbo].[686DP_PolizaSiniestro] AS ps 
        ON ps.CodSiniestro = sini.CodSiniestro
    INNER JOIN [dbo].[686DP_Poliza] AS pol
        ON pol.DP686_NPoliza = ps.DP686_NPoliza
    INNER JOIN [dbo].[686DP_Plan] AS pl
        ON pol.DP686_CodPlan = pl.DP686_CodigoPlan
    INNER JOIN [dbo].[686DP_PlanesCoberturas] AS pc
        ON pc.DP686_CodigoPlan = pl.DP686_CodigoPlan
    INNER JOIN [dbo].[686DP_Cobertura] AS c
        ON c.CodigoCobertura = pc.CodigoCobertura
    WHERE sini.Estado = 0 
      AND sini.Descripcion = c.DP686_Descripcion;

    ------------------------------------------------------------
    -- 2️⃣ Devuelve todas las filas evaluadas y actualizadas
    ------------------------------------------------------------
    SELECT 
        pol.DP686_NPoliza,
        sini.CodSiniestro,
        sini.Fecha,
        sini.ValorDeReparacion,
        sini.ValorDelBien,
        sini.Valor AS ValorRegistrado,
        sini.Descripcion,
        pl.DP686_CodigoPlan,
        pl.DP686_Franquicia,
        c.DP686_Descripcion AS CoberturaDescripcion,
        c.DP686_SumaAsegurada,

        -- Valor a considerar
        CASE 
            WHEN sini.ValorDelBien < sini.ValorDeReparacion 
                THEN sini.ValorDelBien 
            ELSE sini.ValorDeReparacion 
        END AS ValorConsiderado,

        -- Evaluación del sistema
        CASE 
            WHEN (
                (
                    CASE 
                        WHEN sini.ValorDelBien < sini.ValorDeReparacion 
                            THEN sini.ValorDelBien 
                        ELSE sini.ValorDeReparacion 
                    END
                ) > pl.DP686_Franquicia
                AND
                (
                    CASE 
                        WHEN sini.ValorDelBien < sini.ValorDeReparacion 
                            THEN sini.ValorDelBien 
                        ELSE sini.ValorDeReparacion 
                    END
                ) <= c.DP686_SumaAsegurada
            )
            THEN 'CALIFICA'

            WHEN (
                (
                    CASE 
                        WHEN sini.ValorDelBien < sini.ValorDeReparacion 
                            THEN sini.ValorDelBien 
                        ELSE sini.ValorDeReparacion 
                    END
                ) > pl.DP686_Franquicia
                AND sini.ValorDelBien > c.DP686_SumaAsegurada 
                AND sini.ValorDeReparacion > c.DP686_SumaAsegurada
            )
            THEN 'CALIFICA (COMPENSADO HASTA SUMA ASEGURADA)'

            ELSE 'NO CALIFICA'
        END AS EvaluacionSistema,

        -- Valor remunerado real
        CASE 
            WHEN sini.Valor = 0 THEN 0 
            ELSE sini.Valor 
        END AS ValorRemunerar

    FROM [dbo].[686DP_Siniestro] AS sini
    INNER JOIN [dbo].[686DP_PolizaSiniestro] AS ps 
        ON ps.CodSiniestro = sini.CodSiniestro
    INNER JOIN [dbo].[686DP_Poliza] AS pol
        ON pol.DP686_NPoliza = ps.DP686_NPoliza
    INNER JOIN [dbo].[686DP_Plan] AS pl
        ON pol.DP686_CodPlan = pl.DP686_CodigoPlan
    INNER JOIN [dbo].[686DP_PlanesCoberturas] AS pc
        ON pc.DP686_CodigoPlan = pl.DP686_CodigoPlan
    INNER JOIN [dbo].[686DP_Cobertura] AS c
        ON c.CodigoCobertura = pc.CodigoCobertura
    WHERE sini.Estado = 0 
      AND sini.Descripcion = c.DP686_Descripcion;
END
GO

PRINT 'Base de datos AseguraYA creada correctamente con todas las tablas, constraints y SPs.';
GO

-- INSERT DE DATOS A TABLAS
GO

------------------------------------------------------------
-- Tabla: [dbo].[686DP_Perfil]
------------------------------------------------------------
SET IDENTITY_INSERT [dbo].[686DP_Perfil] ON;

INSERT INTO [dbo].[686DP_Perfil] ([DP686_PerfilID], [DP686_Nombre])
VALUES 
    (7,  'Administrador General'),
    (17, 'Basico'),
    (18, 'Basiquisimo');

SET IDENTITY_INSERT [dbo].[686DP_Perfil] OFF;
GO

------------------------------------------------------------
-- Tabla: [dbo].[686DP_Familia]
------------------------------------------------------------
SET IDENTITY_INSERT [dbo].[686DP_Familia] ON;

INSERT INTO [dbo].[686DP_Familia] ([DP686_FamiliaID], [DP686_Nombre], [DP686_Profundidad])
VALUES
    (1,  'DP_Admin',          0),
    (2,  'DP_Maestro',        0),
    (3,  'DP_Contratacion',   0),
    (8,  'DP_Usuario',        0),
    (11, 'Siniestros',        0);

SET IDENTITY_INSERT [dbo].[686DP_Familia] OFF;
GO

------------------------------------------------------------
-- Tabla: [dbo].[686DP_PermisoSimple]
------------------------------------------------------------
SET IDENTITY_INSERT [dbo].[686DP_PermisoSimple] ON;

INSERT INTO [dbo].[686DP_PermisoSimple] ([DP686_PermisoID], [DP686_Nombre])
VALUES
    (1,  'DP_GestionDeUsuarios'),
    (2,  'DP_GestionDePerfiles'),
    (3,  'DP_BitacoraDeEventos'),
    (4,  'DP_GestionDeRespaldo'),
    (5,  'DP_GestionDeClientes'),
    (6,  'DP_GestionDeProductos'),
    (7,  'DP_GenerarContratacion'),
    (8,  'DP_ModificarSeguro'),
    (9,  'DP_EliminarSeguro'),
    (10, 'DP_CerrarSesion'),
    (11, 'DP_CambiarIdioma'),
    (12, 'DP_Polizas'),
    (16, 'DP_CambiarContraseña'),
    (18, 'RegistrarSiniestro'),
    (19, 'AuditarSiniestro'),
    (20, 'ReporteSiniestro');

SET IDENTITY_INSERT [dbo].[686DP_PermisoSimple] OFF;
GO

------------------------------------------------------------
-- Tabla: [dbo].[686DP_FamiliaPermiso]
------------------------------------------------------------
INSERT INTO [dbo].[686DP_FamiliaPermiso] ([DP686_FamiliaID], [DP686_PermisoID])
VALUES
    (1, 2),
    (8, 10),
    (1, 4),
    (1, 1),
    (2, 6),
    (2, 5),
    (3, 7),
    (3, 8),
    (8, 16),
    (1, 3),
    (11, 18),
    (11, 19),
    (3, 9);
GO

------------------------------------------------------------
-- Tabla: [dbo].[686DP_PerfilFamilia]
------------------------------------------------------------
INSERT INTO [dbo].[686DP_PerfilFamilia] ([DP686_FamiliaID], [DP686_PerfilID])
VALUES
    (1, 7),
    (11, 7),
    (3, 7),
    (2, 7),
    (8, 18);
GO

------------------------------------------------------------
-- Tabla: [dbo].[686DP_PerfilPermiso]
------------------------------------------------------------
INSERT INTO [dbo].[686DP_PerfilPermiso] ([DP686_PerfilID], [DP686_PermisoID])
VALUES
    (7, 16),
    (7, 11),
    (7, 10),
    (7, 20),
    (17, 10),
    (17, 11),
    (7, 12);
GO


------------------------------------------------------------
-- Tabla: [dbo].[686DP_Usuario]
------------------------------------------------------------
INSERT INTO [dbo].[686DP_Usuario] (
    [DP686_DNI],
    [DP686_Nombre],
    [DP686_Apellido],
    [DP686_Email],
    [DP686_Usuario],
    [DP686_Contraseña],
    [DP686_Activo],
    [DP686_Bloqueado],
    [DP686_CambiarContraseña],
    [DP686_PerfilID],
    [DP686_Idioma]
)
VALUES
    (46198686, 'Dana',  'Perelmuter',  'dperelmuter25@gmail.com',      'Dana.Perelmuter', 'e858203ce7d726e217bd22fc08d7cc3bb2b0ec11a9c92298eddfcac9d9125b6a', 1, 0, 0, 7,  'Ingles');
GO

------------------------------------------------------------
-- Tabla: [dbo].[686DP_UsuarioIntentos]
------------------------------------------------------------
INSERT INTO [dbo].[686DP_UsuarioIntentos] ([DP686_DNI], [DP686_intentos])
VALUES
    (46198686, 0);
GO

