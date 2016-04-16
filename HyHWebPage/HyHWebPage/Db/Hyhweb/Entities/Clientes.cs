namespace HyHWebPage.Db.Hyhweb.Entities {
    
    public class Clientes : IHyhWebEntity
    {
        public virtual int Id { get; set; }
        public virtual ClientesEstadoCt ClientesEstadoCt { get; set; }
        public virtual string ClaveCliente { get; set; }
        public virtual string UnidadEntrega { get; set; }
    }
}
