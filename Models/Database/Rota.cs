﻿using System.ComponentModel.DataAnnotations.Schema;

namespace TCC_API.Models.Database
{
    public class Rota : BaseTable
    {
        public long? IdRotaParadaOrigem { get; set; }

        public long? IdRotaParadaDestino { get; set; }

    }
}