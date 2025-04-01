namespace UGB.Domain.Entities
{
    public partial class ra_hor_horarios
    {
        public int hor_codigo {get;set;}
        public string hor_grupo {get;set;}
        public int hor_codpla {get;set;}
        public string hor_codmat {get;set;}
        public int hor_codcil {get;set;}
        public int hor_capacidad {get;set;}

        public virtual ra_plm_planes_materias ra_plm_planes_materias {get; set;}
        public virtual ra_cil_ciclo ra_cil_ciclo {get; set;}
        public virtual ra_mat_materias ra_mat_materias {get; set;}
    }
}