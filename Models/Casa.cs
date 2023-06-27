namespace Decorator1.Models
{
    // Clase base para las casas
    public abstract class Casa
    {
        public abstract string ObtenerDescripcion();
        public abstract decimal ObtenerPrecio();
    }

    public class CasaLujosa : Casa
    {
        public override string ObtenerDescripcion()
        {
            return "Casa lujosa";
        }

        public override decimal ObtenerPrecio()
        {
            return 500000;
        }
    }

    public class CasaNormal : Casa
    {
        public override string ObtenerDescripcion()
        {
            return "Casa normal";
        }

        public override decimal ObtenerPrecio()
        {
            return 100000;
        }
    }

    public class CasaEconomica : Casa
    {
        public override string ObtenerDescripcion()
        {
            return "Casa económica";
        }

        public override decimal ObtenerPrecio()
        {
            return 90000;
        }
    }

    public abstract class DecoradorCasa : Casa
    {
        protected Casa casa;

        public DecoradorCasa(Casa casa)
        {
            this.casa = casa;
        }
    }

    public class DecoradorDormitorioExtra : DecoradorCasa
    {
        public DecoradorDormitorioExtra(Casa casa) : base(casa)
        {
        }

        public override string ObtenerDescripcion()
        {
            return casa.ObtenerDescripcion() + ", dormitorio extra";
        }

        public override decimal ObtenerPrecio()
        {
            return casa.ObtenerPrecio() + 10000;
        }
    }

    public class DecoradorBañoExtra : DecoradorCasa
    {
        public DecoradorBañoExtra(Casa casa) : base(casa)
        {
        }

        public override string ObtenerDescripcion()
        {
            return casa.ObtenerDescripcion() + ", baño extra";
        }

        public override decimal ObtenerPrecio()
        {
            return casa.ObtenerPrecio() + 5000;
        }
    }

    public class CasaViewModel
    {
        public decimal PrecioCasaLujosa { get; set; }
        public decimal PrecioCasaNormal { get; set; }
        public decimal PrecioCasaEconomica { get; set; }

        public string DescripcionCasaLujosa { get; set; }
        public string DescripcionCasaNormal { get; set; }
        public string DescripcionCasaEconomica { get; set; }
    }

}
