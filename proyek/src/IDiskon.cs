
namespace Proyek;

public interface IDiskon
{
    string NamaDiskon { get; }

    decimal HitungDiskon(decimal total);
}
