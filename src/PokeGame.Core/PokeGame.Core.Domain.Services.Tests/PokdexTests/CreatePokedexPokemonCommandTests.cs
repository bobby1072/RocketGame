using AutoFixture;
using BT.Common.Persistence.Shared.Models;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using PokeGame.Core.Domain.Services.Pokedex.Commands;
using PokeGame.Core.Persistence.Repositories.Abstract;
using PokeGame.Core.Schemas;

namespace PokeGame.Core.Domain.Services.Tests.PokdexTests;

public sealed class CreatePokedexPokemonCommandTests
{
    private readonly Fixture _fixture = new();
    private readonly Mock<IPokedexPokemonRepository> _mockPokedexPokemonRepository = new();
    private readonly CreatePokedexPokemonCommand _command;

    public CreatePokedexPokemonCommandTests()
    {
        _command = new CreatePokedexPokemonCommand(
            _mockPokedexPokemonRepository.Object,
            new NullLogger<CreatePokedexPokemonCommand>()
        );
    }

    [Fact]
    public async Task ExecuteAsync_Should_Create_Only_New_Pokemon()
    {
        //Arrange
        var originalPokemon = 
            _fixture
                .CreateMany<PokedexPokemon>().ToArray();
        
        _mockPokedexPokemonRepository
            .Setup(x => x.GetAll())
            .ReturnsAsync(new DbGetManyResult<PokedexPokemon>(originalPokemon));
        
        //Act
        var result = await _command.ExecuteAsync(originalPokemon);
        
        //Assert
        Assert.Equal([], result);
        
        _mockPokedexPokemonRepository.Verify(x => x.GetAll(), Times.Once);
        _mockPokedexPokemonRepository.VerifyNoOtherCalls();
    }
}