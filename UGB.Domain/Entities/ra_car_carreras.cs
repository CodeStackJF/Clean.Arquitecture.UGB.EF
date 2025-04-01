namespace UGB.Domain.Entities
{
    public partial class ra_car_carreras
    {
        public int car_codigo {get;set;}
	    public string car_nombre {get;set;}

        public virtual IEnumerable<ra_pla_planes> ra_pla_planes {get; }
    }
}