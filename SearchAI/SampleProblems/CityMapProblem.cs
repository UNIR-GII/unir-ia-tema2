using SearchAI.Models;

namespace SearchAI.SampleProblems;

public static class CityMapProblem
{
    public static SearchProblem<string> Create()
    {
        var connections = new Dictionary<string, List<string>>
        {
            ["Madrid"] = new() { "Alcalá de Henares", "Toledo", "Guadalajara" },
            ["Alcalá de Henares"] = new() { "Madrid", "Guadalajara", "Torrejón de Ardoz" },
            ["Toledo"] = new() { "Madrid", "Talavera de la Reina", "Ciudad Real" },
            ["Guadalajara"] = new() { "Madrid", "Alcalá de Henares", "Cuenca" },
            ["Talavera de la Reina"] = new() { "Toledo", "Navalmoral de la Mata" },
            ["Ciudad Real"] = new() { "Toledo", "Puertollano", "Valdepeñas" },
            ["Cuenca"] = new() { "Guadalajara", "Albacete", "Teruel" },
            ["Albacete"] = new() { "Cuenca", "Murcia", "Ciudad Real" },
            ["Murcia"] = new() { "Albacete", "Cartagena", "Lorca" },
            ["Cartagena"] = new() { "Murcia", "Lorca" },
            ["Lorca"] = new() { "Murcia", "Cartagena", "Almería" },
            ["Almería"] = new() { "Lorca", "Granada" },
            ["Granada"] = new() { "Almería", "Jaén", "Málaga" },
            ["Jaén"] = new() { "Granada", "Córdoba" },
            ["Córdoba"] = new() { "Jaén", "Sevilla" },
            ["Sevilla"] = new() { "Córdoba", "Huelva", "Dos Hermanas" },
            ["Huelva"] = new() { "Sevilla", "Badajoz" },
            ["Badajoz"] = new() { "Huelva", "Cáceres" },
            ["Cáceres"] = new() { "Badajoz", "Salamanca" },
            ["Salamanca"] = new() { "Cáceres", "Zamora" },
            ["Zamora"] = new() { "Salamanca", "León" },
            ["León"] = new() { "Zamora", "Oviedo" },
            ["Oviedo"] = new() { "León", "Gijón" },
            ["Gijón"] = new() { "Oviedo", "Avilés" },
            ["Avilés"] = new() { "Gijón", "Oviedo" },
            ["Málaga"] = new() { "Granada", "Marbella", "Córdoba" },
            ["Marbella"] = new() { "Málaga", "Estepona" },
            ["Estepona"] = new() { "Marbella", "Algeciras" },
            ["Algeciras"] = new() { "Estepona", "Cádiz" },
            ["Cádiz"] = new() { "Algeciras", "Jerez de la Frontera" },
            ["Jerez de la Frontera"] = new() { "Cádiz", "Sevilla" },
            ["Valencia"] = new() { "Castellón de la Plana", "Alicante" },
            ["Castellón de la Plana"] = new() { "Valencia", "Teruel" },
            ["Alicante"] = new() { "Valencia", "Elche", "Murcia" },
            ["Elche"] = new() { "Alicante", "Murcia" },
            ["Teruel"] = new() { "Cuenca", "Castellón de la Plana", "Zaragoza" },
            ["Zaragoza"] = new() { "Teruel", "Huesca", "Lleida" },
            ["Huesca"] = new() { "Zaragoza", "Lleida" },
            ["Lleida"] = new() { "Zaragoza", "Huesca", "Barcelona" },
            ["Barcelona"] = new() { "Lleida", "Tarragona", "Girona" },
            ["Tarragona"] = new() { "Barcelona", "Castellón de la Plana" },
            ["Girona"] = new() { "Barcelona", "Figueres" },
            ["Figueres"] = new() { "Girona" },
            ["Bilbao"] = new() { "Vitoria-Gasteiz", "San Sebastián" },
            ["Vitoria-Gasteiz"] = new() { "Bilbao", "Pamplona" },
            ["San Sebastián"] = new() { "Bilbao", "Pamplona" },
            ["Pamplona"] = new() { "San Sebastián", "Vitoria-Gasteiz", "Logroño" },
            ["Logroño"] = new() { "Pamplona", "Zaragoza" },
            ["Santiago de Compostela"] = new() { "A Coruña", "Lugo" },
            ["A Coruña"] = new() { "Santiago de Compostela", "Ferrol" },
            ["Lugo"] = new() { "Santiago de Compostela", "Ourense" },
            ["Ourense"] = new() { "Lugo", "Pontevedra" },
            ["Pontevedra"] = new() { "Ourense", "Vigo" },
            ["Vigo"] = new() { "Pontevedra", "Ourense" },
            ["Santa Cruz de Tenerife"] = new() { "San Cristóbal de La Laguna" },
            ["San Cristóbal de La Laguna"] = new() { "Santa Cruz de Tenerife" },
            ["Las Palmas de Gran Canaria"] = new() { "Telde" },
            ["Telde"] = new() { "Las Palmas de Gran Canaria" },
            ["Dos Hermanas"] = new() { "Sevilla" },
            ["Ferrol"] = new() { "A Coruña" },
            ["Navalmoral de la Mata"] = new() { "Talavera de la Reina" },
            ["Puertollano"] = new() { "Ciudad Real" },
            ["Torrejón de Ardoz"] = new() { "Alcalá de Henares", "Madrid" },
            ["Valdepeñas"] = new() { "Ciudad Real" },            
        };


        return new SearchProblem<string>(
            "Figueres",
            state => state == "Huelva",
            state =>
                connections[state].Select(city => (city, $"Go to {city}", 1))
        );
    }
}