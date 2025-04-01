namespace UGB.Domain.Entities
{
    public partial class ra_pla_planes
    {
        public int pla_codigo {get;set;}
        public string pla_nombre {get;set;}
        public int pla_codcar {get;set;}
        public bool pla_activo {get;set;}

        public virtual ra_car_carreras ra_car_carreras {get; set;}
    }
}