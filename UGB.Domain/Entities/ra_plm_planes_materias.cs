namespace UGB.Domain.Entities
{
    public partial class ra_plm_planes_materias
    {
        public int plm_codpla {get;set;}
        public string plm_codmat {get;set;}
        public int plm_uv {get;set;}
        public int plm_num_mat {get;set;}

        public virtual ra_pla_planes ra_pla_planes {get;}
        public virtual ra_mat_materias ra_mat_materias {get;}
    }
}