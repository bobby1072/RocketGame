namespace PokeGame.Core.Schemas;

public sealed class PokedexPokemonStats: DomainModel<PokedexPokemonStats>
{
    public required int Hp { get; set; }
    public required int Attack { get; set; }
    public required int Defense { get; set; }
    public required int SpecialAttack { get; set; }
    public required int SpecialDefense { get; set; }
    public required int Speed { get; set; }

    public override bool Equals(PokedexPokemonStats? other)
    {
        return other?.Attack == Attack &&
               other?.Defense == Defense &&
               other.Hp == Hp &&
               other.SpecialAttack == SpecialAttack &&
               other.SpecialDefense == SpecialDefense &&
               other.Speed == Speed;
    }


    public PokedexPokemonStatsRawJson ToJson()
    {
        return new PokedexPokemonStatsRawJson
        {
            Attack = Attack,
            Defense = Defense,
            Hp = Hp,
            Speed = Speed,
            SpecialAttack = SpecialAttack,
            SpecialDefense = SpecialDefense,
        };
    }
}