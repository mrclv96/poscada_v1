using Microsoft.EntityFrameworkCore;
using SCADA_A.Datos.Mapping.Colores;
using SCADA_A.Entidades.Colores;
using SCADA_A.Entidades.Productos;
using SCADA_A.Entidades.Estaciones;
using SCADA_A.Datos.Mapping.Productos;
using SCADA_A.Datos.Mapping.Estaciones;
using SCADA_A.Datos.Mapping.Usuarios;
using SCADA_A.Entidades.Usuarios;
using System.Collections.Generic;
using System.Linq;
using System;
using SCADA_A.Entidades.Trace;
using SCADA_A.Datos.Mapping.Trace;
using SCADA_A.Entidades.Produccion;
using SCADA_A.Datos.Mapping.Produccion;
using SCADA_A.Entidades.TPL;
using SCADA_A.Datos.Mapping.TPL;
using SCADA_A.Entidades.OEE;
using SCADA_A.Datos.Mapping.OEE;
using SCADA_A.Entidades.OnePieceFlow;
using SCADA_A.Datos.Mapping.OnePieceFlow;

namespace SCADA_A.Datos
{
    public class DbContextSCADA_A: DbContext
    {
        public DbSet<Color> Colores { get; set; }
        public DbSet<SQP> SQPs { get; set; }
        public DbSet<PosicionModelo> PosicionModelos { get; set; }
        public DbSet<Estacion> Estacions { get; set; }
        public DbSet<Linea> Lineas { get; set; }
        public DbSet<LineaVariante> LineaVariantes { get; set; }
        public DbSet<Secuencia> Secuencias { get; set; }
        public DbSet<Fascia> Fascias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<LogTrace> LogTraces { get; set; }
        public DbSet<ErrTrace> ErrTraces { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Protocolo> Protocolos { get; set; }
        public DbSet<S2019149> S2019149s { get; set; }
        public DbSet<S2019101> S2019101s { get; set; }
        public DbSet<S2019103> S2019103s { get; set; }
        public DbSet<S10920M> S10920Ms { get; set; }
        public DbSet<S10921M> S10921Ms { get; set; }
        public DbSet<S10922M> S10922Ms { get; set; }
        public DbSet<S10923M> S10923Ms { get; set; }
        public DbSet<S10924M> S10924Ms { get; set; }
        public DbSet<S4160273> S4160273s { get; set; }
        public DbSet<X10376> X10376s { get; set; }
        public DbSet<PunchData> PunchDatas { get; set; }
        public DbSet<WeldData> WeldDatas { get; set; }
        public DbSet<ScanData> ScanDatas { get; set; }
        public DbSet<TorqueData> TorqueDatas { get; set; }
        public DbSet<Kit> Kits { get; set; }
        public DbSet<KitComponentes> KitComponentess { get; set; }
        public DbSet<OrdenKit> OrdenKits { get; set; }

        //Paint OEE
        public DbSet<App_Types> App_Typess { get; set; }
        public DbSet<App_Colors> App_Colors { get; set; }
        public DbSet<Order_Skid_Data> Order_Skid_Datas { get; set; }
        public DbSet<SAPScrapV> SAPScrapVs { get; set; }
        public DbSet<ProductCostV> ProductCostVs { get; set; }
        public DbSet<Protocol> Protocols { get; set; }
        public DbSet<SkidProtocol> SkidProtocols { get; set; }

        public DbContextSCADA_A(DbContextOptions<DbContextSCADA_A> options) : base(options)
        {

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ColorMap());
            modelBuilder.ApplyConfiguration(new SQPMap());
            modelBuilder.ApplyConfiguration(new PosicionModeloMap());
            modelBuilder.ApplyConfiguration(new EstacionMap());
            modelBuilder.ApplyConfiguration(new LineaMap());
            modelBuilder.ApplyConfiguration(new LineaVarianteMap());
            modelBuilder.ApplyConfiguration(new SecuenciaMap());
            modelBuilder.ApplyConfiguration(new FasciaMap());
            modelBuilder.ApplyConfiguration(new ProductoMap());
            modelBuilder.ApplyConfiguration(new RolMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new LogTraceMap());
            modelBuilder.ApplyConfiguration(new ErrTraceMap());
            modelBuilder.ApplyConfiguration(new OrdenMap());
            modelBuilder.ApplyConfiguration(new ProtocoloMap());
            modelBuilder.ApplyConfiguration(new S2019101Map());
            modelBuilder.ApplyConfiguration(new S2019103Map());
            modelBuilder.ApplyConfiguration(new S2019149Map());
            modelBuilder.ApplyConfiguration(new S10920MMap());
            modelBuilder.ApplyConfiguration(new S10921MMap());
            modelBuilder.ApplyConfiguration(new S10922MMap());
            modelBuilder.ApplyConfiguration(new S10923MMap());
            modelBuilder.ApplyConfiguration(new S10924MMap());
            modelBuilder.ApplyConfiguration(new X10376Map());
            modelBuilder.ApplyConfiguration(new S4160273Map());
            modelBuilder.ApplyConfiguration(new PunchDataMap());
            modelBuilder.ApplyConfiguration(new WeldDataMap());
            modelBuilder.ApplyConfiguration(new ScanDataMap());
            modelBuilder.ApplyConfiguration(new TorqueDataMap());
            modelBuilder.ApplyConfiguration(new KitMap());
            modelBuilder.ApplyConfiguration(new KitComponentesMap());
            modelBuilder.ApplyConfiguration(new OrdenKitMap());

            //Paint OEE
            modelBuilder.ApplyConfiguration(new App_TypesMap());
            modelBuilder.ApplyConfiguration(new App_ColorsMap());
            modelBuilder.ApplyConfiguration(new Order_Skid_DataMap());
            modelBuilder.ApplyConfiguration(new SAPScrapVMap());
            modelBuilder.ApplyConfiguration(new ProductCostVMap());
            modelBuilder.ApplyConfiguration(new ProtocolMap());
            modelBuilder.ApplyConfiguration(new SkidProtocolMap());

#pragma warning disable CS0618 // Type or member is obsolete
            modelBuilder.Ignore<ResultGOODSBOMbuscarfascia>(); //ignore create the table for the stored procedure
            modelBuilder.Query<ResultGOODSBOMbuscarfascia>();  //register stored procedure.
            //Paint OEE
            modelBuilder.Ignore<ScrapPorModelo>(); //ignore create the table for the stored procedure
            modelBuilder.Query<ScrapPorModelo>();  //register stored procedure.
            modelBuilder.Ignore<MaxMinSQPTransaction>(); //ignore create the table for the stored procedure
            modelBuilder.Query<MaxMinSQPTransaction>();  //register stored procedure.
            modelBuilder.Ignore<ScrapPorProductoCosto>(); //ignore create the table for the stored procedure
            modelBuilder.Query<ScrapPorProductoCosto>(); //register stored procedure.
            modelBuilder.Ignore<TotalPiezasTiempoCostporTipo>();
            modelBuilder.Query<TotalPiezasTiempoCostporTipo>();
            modelBuilder.Ignore<DistribucionScrap>();
            modelBuilder.Query<DistribucionScrap>();
            modelBuilder.Ignore<DistribucionCostoScrap>();
            modelBuilder.Query<DistribucionCostoScrap>();
            modelBuilder.Ignore<DistribucionCostoScrapPorTipo>();
            modelBuilder.Query<DistribucionCostoScrapPorTipo>();
            modelBuilder.Ignore<DistribucionCostoScrapPorTipos>();
            modelBuilder.Query<DistribucionCostoScrapPorTipos>();
            modelBuilder.Ignore<ScrapPorDefectoCosto>();
            modelBuilder.Query<ScrapPorDefectoCosto>();
            modelBuilder.Ignore<TotalPiezasProducidas>();
            modelBuilder.Query<TotalPiezasProducidas>();
            modelBuilder.Ignore<TotalPiezasCostporModelo>();
            modelBuilder.Query<TotalPiezasCostporModelo>();


#pragma warning restore CS0618 // Type or member is obsolete

        }

        public List<ResultGOODSBOMbuscarfascia> GOODSBOM_buscar_fascia(string sqlQuery)
        {
            List<ResultGOODSBOMbuscarfascia> lst = new List<ResultGOODSBOMbuscarfascia>();
            try
            {
            #pragma warning disable CS0618 // Type or member is obsolete
                lst = this.Query<ResultGOODSBOMbuscarfascia>().FromSqlRaw<ResultGOODSBOMbuscarfascia>(sqlQuery).ToList();
            #pragma warning restore CS0618 // Type or member is obsolete
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // Info.  
            return lst;
        }
        
        //Paint OEE
        public List<ScrapPorModelo> Scrap_Por_Modelo(string sqlQuery)
        {
            List<ScrapPorModelo> lst = new List<ScrapPorModelo>();
            try
            {
#pragma warning disable CS0618 // Type or member is obsolete
                lst = this.Query<ScrapPorModelo>().FromSqlRaw<ScrapPorModelo>(sqlQuery).ToList();
#pragma warning restore CS0618 // Type or member is obsolete
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // Info.  
            return lst;
        }

        public List<ScrapPorProductoCosto> Scrap_Por_Producto_Costos(string sqlQuery)
        {
            List<ScrapPorProductoCosto> lst = new List<ScrapPorProductoCosto>();
            try
            {
#pragma warning disable CS0618 // Type or member is obsolete
                lst = this.Query<ScrapPorProductoCosto>().FromSqlRaw<ScrapPorProductoCosto>(sqlQuery).ToList();
#pragma warning restore CS0618 // Type or member is obsolete
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // Info.  
            return lst;
        }

        public List<MaxMinSQPTransaction> MaxMin_SQP_Transaction(string sqlQuery)
        {
            List<MaxMinSQPTransaction> lst = new List<MaxMinSQPTransaction>();
            try
            {
#pragma warning disable CS0618 // Type or member is obsolete
                lst = this.Query<MaxMinSQPTransaction>().FromSqlRaw<MaxMinSQPTransaction>(sqlQuery).ToList();
#pragma warning restore CS0618 // Type or member is obsolete
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // Info.  
            return lst;
        }

        public List<TotalPiezasTiempoCostporTipo> Total_Piezas_Tiempo_Cost_por_Tipo(string sqlQuery)
        {
            List<TotalPiezasTiempoCostporTipo> lst = new List<TotalPiezasTiempoCostporTipo>();
            try
            {
#pragma warning disable CS0618 // Type or member is obsolete
                lst = this.Query<TotalPiezasTiempoCostporTipo>().FromSqlRaw<TotalPiezasTiempoCostporTipo>(sqlQuery).ToList();
#pragma warning restore CS0618 // Type or member is obsolete
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // Info.  
            return lst;
        }

        public List<DistribucionScrap> Distribucion_Scrap(string sqlQuery)
        {
            List<DistribucionScrap> lst = new List<DistribucionScrap>();
            try
            {
#pragma warning disable CS0618 // Type or member is obsolete
                lst = this.Query<DistribucionScrap>().FromSqlRaw<DistribucionScrap>(sqlQuery).ToList();
#pragma warning restore CS0618 // Type or member is obsolete
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // Info.  
            return lst;
        }

        public List<DistribucionCostoScrap> Distribucion_Costo_Scrap(string sqlQuery)
        {
            List<DistribucionCostoScrap> lst = new List<DistribucionCostoScrap>();
            try
            {
#pragma warning disable CS0618 // Type or member is obsolete
                lst = this.Query<DistribucionCostoScrap>().FromSqlRaw<DistribucionCostoScrap>(sqlQuery).ToList();
#pragma warning restore CS0618 // Type or member is obsolete
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // Info.  
            return lst;
        }

        public List<DistribucionCostoScrapPorTipo> Distribucion_Costo_Scrap_Por_Tipo(string sqlQuery)
        {
            List<DistribucionCostoScrapPorTipo> lst = new List<DistribucionCostoScrapPorTipo>();
            try
            {
#pragma warning disable CS0618 // Type or member is obsolete
                lst = this.Query<DistribucionCostoScrapPorTipo>().FromSqlRaw<DistribucionCostoScrapPorTipo>(sqlQuery).ToList();
#pragma warning restore CS0618 // Type or member is obsolete
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // Info.  
            return lst;
        }

        public List<DistribucionCostoScrapPorTipos> Distribucion_Costo_Scrap_Por_Tipos(string sqlQuery)
        {
            List<DistribucionCostoScrapPorTipos> lst = new List<DistribucionCostoScrapPorTipos>();
            try
            {
#pragma warning disable CS0618 // Type or member is obsolete
                lst = this.Query<DistribucionCostoScrapPorTipos>().FromSqlRaw<DistribucionCostoScrapPorTipos>(sqlQuery).ToList();
#pragma warning restore CS0618 // Type or member is obsolete
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // Info.  
            return lst;
        }

        public List<ScrapPorDefectoCosto> Scrap_Por_Defecto_Costo(string sqlQuery)
        {
            List<ScrapPorDefectoCosto> lst = new List<ScrapPorDefectoCosto>();
            try
            {
#pragma warning disable CS0618 // Type or member is obsolete
                lst = this.Query<ScrapPorDefectoCosto>().FromSqlRaw<ScrapPorDefectoCosto>(sqlQuery).ToList();
#pragma warning restore CS0618 // Type or member is obsolete
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // Info.  
            return lst;
        }

        public List<TotalPiezasProducidas> Total_Piezas_Producidas(string sqlQuery)
        {
            List<TotalPiezasProducidas> lst = new List<TotalPiezasProducidas>();
            try
            {
#pragma warning disable CS0618 // Type or member is obsolete
                lst = this.Query<TotalPiezasProducidas>().FromSqlRaw<TotalPiezasProducidas>(sqlQuery).ToList();
#pragma warning restore CS0618 // Type or member is obsolete
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // Info.  
            return lst;
        }

        public List<TotalPiezasCostporModelo> Total_Piezas_Cost_por_Modelo(string sqlQuery)
        {
            List<TotalPiezasCostporModelo> lst = new List<TotalPiezasCostporModelo>();
            try
            {
#pragma warning disable CS0618 // Type or member is obsolete
                lst = this.Query<TotalPiezasCostporModelo>().FromSqlRaw<TotalPiezasCostporModelo>(sqlQuery).ToList();
#pragma warning restore CS0618 // Type or member is obsolete
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // Info.  
            return lst;
        }

    }
}
