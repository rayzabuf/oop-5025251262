
namespace Proyek;

public interface IDiskon
{
    string NamaDiskon { get; }

    decimal HitungPotongan(decimal subtotal);
}
