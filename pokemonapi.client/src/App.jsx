import React, { useEffect, useState } from "react";
import "./App.css";

const API_URL = "https://localhost:7131/api/pokemon";

function App() {
    const [pokemons, setPokemons] = useState([]);
    const [search, setSearch] = useState("");
    const [filteredPokemons, setFilteredPokemons] = useState([]);
    const [typeFilter, setTypeFilter] = useState("all");
    const [generationFilter, setGenerationFilter] = useState("all");

    useEffect(() => {
        fetch(API_URL)
            .then((response) => response.json())
            .then((data) => {
                setPokemons(data);
                setFilteredPokemons(data);
            })
            .catch((error) => console.error("Error fetching Pokémon:", error));
    }, []);

    const handleSearch = () => {
        let result = pokemons;

        if (search) {
            result = result.filter((pokemon) =>
                pokemon.name.toLowerCase().includes(search.toLowerCase())
            );
        }
       
        if (typeFilter !== "all") {
            result = result.filter((pokemon) =>
                pokemon.type.toLowerCase().includes(typeFilter.toLowerCase())
            );
        }

        if (generationFilter !== "all") {
            result = result.filter((pokemon) => pokemon.generation === parseInt(generationFilter));
        }

        setFilteredPokemons(result);
    };

    return (
        <div className="container">
            <h1>Pokedex</h1>

            <div className="search-container">
                <input
                    type="text"
                    placeholder="Search Pokemon"
                    value={search}
                    onChange={(e) => setSearch(e.target.value)}
                />
                <button onClick={handleSearch}>Search</button>
            </div>

            <div className="filters-container">
                <select
                    className="filter-dropdown"
                    onChange={(e) => setTypeFilter(e.target.value)}
                    value={typeFilter}
                >
                    <option value="all">Filter by Type</option>
                    <option value="fire">Fire</option>
                    <option value="water">Water</option>
                    <option value="grass">Grass</option>
                    <option value="electric">Electric</option>
                    <option value="ghost">Ghost</option>
                </select>

                <select
                    className="filter-dropdown"
                    onChange={(e) => setGenerationFilter(e.target.value)}
                    value={generationFilter}
                >
                    <option value="all">Filter by Generation</option>
                    <option value="1">Generation 1</option>
                    <option value="2">Generation 2</option>
                    <option value="3">Generation 3</option>
                </select>
            </div>

            <div className="row">
                {filteredPokemons.map((pokemon) => (
                    <div key={pokemon.id} className="col-md-4 mb-4">
                        <div className="card">
                            <img src={pokemon.imageUrl} alt={pokemon.name} className="pokemon-image" />
                            <div className="card-body">
                                <h5 className="card-title">{pokemon.name}</h5>
                                <p className="card-text">
                                    <strong>Type:</strong> {pokemon.type} <br />
                                    <strong>Power Level:</strong> {pokemon.powerLevel} <br />
                                    <strong>Base Evolution:</strong> {pokemon.baseEvolution} <br />
                                    <strong>Next Evolution:</strong> {pokemon.nextEvolution} <br />
                                    <strong>Weight:</strong> {pokemon.weight} kg <br />
                                    <strong>Height:</strong> {pokemon.height} m
                                </p>
                            </div>
                            <div className="card-footer">
                                <small>Generation: {pokemon.generation}</small>
                            </div>
                        </div>
                    </div>
                ))}
            </div>

        </div>
    );
}

export default App;
