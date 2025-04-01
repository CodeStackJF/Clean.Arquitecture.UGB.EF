namespace UGB.Domain.Entities
{
    public partial class ra_ins_inscripcion
    {
        public int ins_codigo {get;set;}
        public int ins_codper {get;set;}
        public int ins_codhor {get;set;}
        public int ins_codpla {get;set;}
        public string ins_codmat {get;set;}
        public string ins_estado {get;set;}
        public DateTime ins_fecha {get;set;}

        public virtual ra_per_personas ra_per_personas {get; set;}
        public virtual ra_hor_horarios ra_hor_horarios {get; set; }
        public virtual ra_plm_planes_materias ra_plm_planes_materias {get; set; }
    }
}