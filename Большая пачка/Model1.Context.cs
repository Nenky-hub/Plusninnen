﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Большая_пачка
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Большая_пачкаEntities : DbContext
    {

        private static Большая_пачкаEntities _context;
        public static Большая_пачкаEntities GetContext()
        {
            if (_context == null) _context = new Большая_пачкаEntities();
            return _context;
        }
        public Большая_пачкаEntities()
            : base("name=Большая_пачкаEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Агент> Агент { get; set; }
        public virtual DbSet<Аналитик> Аналитик { get; set; }
        public virtual DbSet<Доставка> Доставка { get; set; }
        public virtual DbSet<Заказ_материалов> Заказ_материалов { get; set; }
        public virtual DbSet<Заявка> Заявка { get; set; }
        public virtual DbSet<История> История { get; set; }
        public virtual DbSet<История_поставок> История_поставок { get; set; }
        public virtual DbSet<Каталог_готовой_продукции> Каталог_готовой_продукции { get; set; }
        public virtual DbSet<Мастер_производства> Мастер_производства { get; set; }
        public virtual DbSet<Материалы> Материалы { get; set; }
        public virtual DbSet<Менеджер> Менеджер { get; set; }
        public virtual DbSet<Поставщик> Поставщик { get; set; }
        public virtual DbSet<Предложение_для_агента> Предложение_для_агента { get; set; }
        public virtual DbSet<Продукция> Продукция { get; set; }
        public virtual DbSet<Склад> Склад { get; set; }
        public virtual DbSet<Смена> Смена { get; set; }
        public virtual DbSet<Сотрудники> Сотрудники { get; set; }
        public virtual DbSet<Статистика_по_сотруднику> Статистика_по_сотруднику { get; set; }
        public virtual DbSet<Точка_подажи> Точка_подажи { get; set; }
        public virtual DbSet<Турникет> Турникет { get; set; }
        public virtual DbSet<Цех> Цех { get; set; }
    }
}
