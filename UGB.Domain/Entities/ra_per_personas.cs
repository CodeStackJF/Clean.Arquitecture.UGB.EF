namespace UGB.Domain.Entities
{
    public partial class ra_per_personas
    {
        public int per_codigo {get;set;}
        public string per_nombres {get;set;}
        public string per_apellidos {get;set;}
        public string per_nombres_apellidos {get;set;}
        public string per_apellidos_nombres {get;set;}
        public string per_carnet {get;set;}
        public DateTime per_fecha_nacimiento {get;set;}
        public string per_dui {get;set;}
        public bool per_activo {get;set;}
        public int per_codpla {get;set;}

        public virtual IEnumerable<ra_ins_inscripcion> ra_ins_inscripcion {get;}
        public virtual ra_pla_planes ra_pla_planes {get; set;}
    }
}