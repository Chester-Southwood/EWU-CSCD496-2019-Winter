﻿using Microsoft.EntityFrameworkCore;
using src.Model;
using src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace src.Services
{
    public class PairingService
    {
        private ApplicationDbContext Db { get; }

        public PairingService(ApplicationDbContext db)
        {
            Db = db;
        }

        public void AddPairing(Pairing pair)
        {
            Db.Pairs.AddAsync(pair).Wait();
            Db.SaveChangesAsync();
        }
    }
}
