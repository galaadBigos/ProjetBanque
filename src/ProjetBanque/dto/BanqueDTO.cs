﻿using ProjetBanque.Abstractions.DTO;

namespace ProjetBanque.dto
{
    public class BanqueDTO : IDTO
    {
        public string Nom { get; set; } = string.Empty;
        public List<ClientDTO> Clients { get; set; } = new List<ClientDTO>();
        public List<CompteDTO> Comptes { get; set; } = new List<CompteDTO>();
    }
}