﻿namespace JsonWebTokenSecurity.Models
{
    public class Entity
    {
        public int Id { get; set; }
        public string? KullaniciAdi { get; set; }
        public string? Sifre { get; set; }
        public string? Rol { get; set; }
    }
}
