﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Notfy_LinqToSql
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="BD_NOTFY")]
	public partial class NotfyDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertNotificacao(Notificacao instance);
    partial void UpdateNotificacao(Notificacao instance);
    partial void DeleteNotificacao(Notificacao instance);
    partial void InsertNotificador(Notificador instance);
    partial void UpdateNotificador(Notificador instance);
    partial void DeleteNotificador(Notificador instance);
    partial void InsertNotificando(Notificando instance);
    partial void UpdateNotificando(Notificando instance);
    partial void DeleteNotificando(Notificando instance);
    partial void InsertEndereco(Endereco instance);
    partial void UpdateEndereco(Endereco instance);
    partial void DeleteEndereco(Endereco instance);
    #endregion
		
		public NotfyDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["BD_NOTFYConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public NotfyDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public NotfyDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public NotfyDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public NotfyDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Notificacao> Notificacaos
		{
			get
			{
				return this.GetTable<Notificacao>();
			}
		}
		
		public System.Data.Linq.Table<Notificador> Notificadors
		{
			get
			{
				return this.GetTable<Notificador>();
			}
		}
		
		public System.Data.Linq.Table<Notificando> Notificandos
		{
			get
			{
				return this.GetTable<Notificando>();
			}
		}
		
		public System.Data.Linq.Table<Endereco> Enderecos
		{
			get
			{
				return this.GetTable<Endereco>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Notificacao")]
	public partial class Notificacao : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private int _NotificandoID;
		
		private int _MatriculaImovel;
		
		private int _NotificadorID;
		
		private System.Nullable<int> _Sequencia;
		
		private System.Nullable<System.DateTime> _Tentativa1;
		
		private System.Nullable<System.DateTime> _Tentativa2;
		
		private System.Nullable<System.DateTime> _Tentativa3;
		
		private System.Nullable<byte> _Concluido;
		
		private string _Observacao;
		
		private bool _Status;
		
		private EntityRef<Notificador> _Notificador;
		
		private EntityRef<Notificando> _Notificando;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnNotificandoIDChanging(int value);
    partial void OnNotificandoIDChanged();
    partial void OnMatriculaImovelChanging(int value);
    partial void OnMatriculaImovelChanged();
    partial void OnNotificadorIDChanging(int value);
    partial void OnNotificadorIDChanged();
    partial void OnSequenciaChanging(System.Nullable<int> value);
    partial void OnSequenciaChanged();
    partial void OnTentativa1Changing(System.Nullable<System.DateTime> value);
    partial void OnTentativa1Changed();
    partial void OnTentativa2Changing(System.Nullable<System.DateTime> value);
    partial void OnTentativa2Changed();
    partial void OnTentativa3Changing(System.Nullable<System.DateTime> value);
    partial void OnTentativa3Changed();
    partial void OnConcluidoChanging(System.Nullable<byte> value);
    partial void OnConcluidoChanged();
    partial void OnObservacaoChanging(string value);
    partial void OnObservacaoChanged();
    partial void OnStatusChanging(bool value);
    partial void OnStatusChanged();
    #endregion
		
		public Notificacao()
		{
			this._Notificador = default(EntityRef<Notificador>);
			this._Notificando = default(EntityRef<Notificando>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NotificandoID", DbType="Int NOT NULL")]
		public int NotificandoID
		{
			get
			{
				return this._NotificandoID;
			}
			set
			{
				if ((this._NotificandoID != value))
				{
					if (this._Notificando.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnNotificandoIDChanging(value);
					this.SendPropertyChanging();
					this._NotificandoID = value;
					this.SendPropertyChanged("NotificandoID");
					this.OnNotificandoIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MatriculaImovel", DbType="Int NOT NULL")]
		public int MatriculaImovel
		{
			get
			{
				return this._MatriculaImovel;
			}
			set
			{
				if ((this._MatriculaImovel != value))
				{
					this.OnMatriculaImovelChanging(value);
					this.SendPropertyChanging();
					this._MatriculaImovel = value;
					this.SendPropertyChanged("MatriculaImovel");
					this.OnMatriculaImovelChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NotificadorID", DbType="Int NOT NULL")]
		public int NotificadorID
		{
			get
			{
				return this._NotificadorID;
			}
			set
			{
				if ((this._NotificadorID != value))
				{
					if (this._Notificador.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnNotificadorIDChanging(value);
					this.SendPropertyChanging();
					this._NotificadorID = value;
					this.SendPropertyChanged("NotificadorID");
					this.OnNotificadorIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Sequencia", DbType="Int")]
		public System.Nullable<int> Sequencia
		{
			get
			{
				return this._Sequencia;
			}
			set
			{
				if ((this._Sequencia != value))
				{
					this.OnSequenciaChanging(value);
					this.SendPropertyChanging();
					this._Sequencia = value;
					this.SendPropertyChanged("Sequencia");
					this.OnSequenciaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Tentativa1", DbType="DateTime")]
		public System.Nullable<System.DateTime> Tentativa1
		{
			get
			{
				return this._Tentativa1;
			}
			set
			{
				if ((this._Tentativa1 != value))
				{
					this.OnTentativa1Changing(value);
					this.SendPropertyChanging();
					this._Tentativa1 = value;
					this.SendPropertyChanged("Tentativa1");
					this.OnTentativa1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Tentativa2", DbType="DateTime")]
		public System.Nullable<System.DateTime> Tentativa2
		{
			get
			{
				return this._Tentativa2;
			}
			set
			{
				if ((this._Tentativa2 != value))
				{
					this.OnTentativa2Changing(value);
					this.SendPropertyChanging();
					this._Tentativa2 = value;
					this.SendPropertyChanged("Tentativa2");
					this.OnTentativa2Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Tentativa3", DbType="DateTime")]
		public System.Nullable<System.DateTime> Tentativa3
		{
			get
			{
				return this._Tentativa3;
			}
			set
			{
				if ((this._Tentativa3 != value))
				{
					this.OnTentativa3Changing(value);
					this.SendPropertyChanging();
					this._Tentativa3 = value;
					this.SendPropertyChanged("Tentativa3");
					this.OnTentativa3Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Concluido", DbType="TinyInt")]
		public System.Nullable<byte> Concluido
		{
			get
			{
				return this._Concluido;
			}
			set
			{
				if ((this._Concluido != value))
				{
					this.OnConcluidoChanging(value);
					this.SendPropertyChanging();
					this._Concluido = value;
					this.SendPropertyChanged("Concluido");
					this.OnConcluidoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Observacao", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string Observacao
		{
			get
			{
				return this._Observacao;
			}
			set
			{
				if ((this._Observacao != value))
				{
					this.OnObservacaoChanging(value);
					this.SendPropertyChanging();
					this._Observacao = value;
					this.SendPropertyChanged("Observacao");
					this.OnObservacaoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="Bit NOT NULL")]
		public bool Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				if ((this._Status != value))
				{
					this.OnStatusChanging(value);
					this.SendPropertyChanging();
					this._Status = value;
					this.SendPropertyChanged("Status");
					this.OnStatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Notificador_Notificacao", Storage="_Notificador", ThisKey="NotificadorID", OtherKey="ID", IsForeignKey=true)]
		public Notificador Notificador
		{
			get
			{
				return this._Notificador.Entity;
			}
			set
			{
				Notificador previousValue = this._Notificador.Entity;
				if (((previousValue != value) 
							|| (this._Notificador.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Notificador.Entity = null;
						previousValue.Notificacaos.Remove(this);
					}
					this._Notificador.Entity = value;
					if ((value != null))
					{
						value.Notificacaos.Add(this);
						this._NotificadorID = value.ID;
					}
					else
					{
						this._NotificadorID = default(int);
					}
					this.SendPropertyChanged("Notificador");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Notificando_Notificacao", Storage="_Notificando", ThisKey="NotificandoID", OtherKey="ID", IsForeignKey=true)]
		public Notificando Notificando
		{
			get
			{
				return this._Notificando.Entity;
			}
			set
			{
				Notificando previousValue = this._Notificando.Entity;
				if (((previousValue != value) 
							|| (this._Notificando.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Notificando.Entity = null;
						previousValue.Notificacaos.Remove(this);
					}
					this._Notificando.Entity = value;
					if ((value != null))
					{
						value.Notificacaos.Add(this);
						this._NotificandoID = value.ID;
					}
					else
					{
						this._NotificandoID = default(int);
					}
					this.SendPropertyChanged("Notificando");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Notificador")]
	public partial class Notificador : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Nome;
		
		private string _Telefone;
		
		private string _CPF;
		
		private string _Email;
		
		private bool _Tipo;
		
		private string _Usuario;
		
		private string _Senha;
		
		private bool _Status;
		
		private EntitySet<Notificacao> _Notificacaos;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnNomeChanging(string value);
    partial void OnNomeChanged();
    partial void OnTelefoneChanging(string value);
    partial void OnTelefoneChanged();
    partial void OnCPFChanging(string value);
    partial void OnCPFChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnTipoChanging(bool value);
    partial void OnTipoChanged();
    partial void OnUsuarioChanging(string value);
    partial void OnUsuarioChanged();
    partial void OnSenhaChanging(string value);
    partial void OnSenhaChanged();
    partial void OnStatusChanging(bool value);
    partial void OnStatusChanged();
    #endregion
		
		public Notificador()
		{
			this._Notificacaos = new EntitySet<Notificacao>(new Action<Notificacao>(this.attach_Notificacaos), new Action<Notificacao>(this.detach_Notificacaos));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nome", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string Nome
		{
			get
			{
				return this._Nome;
			}
			set
			{
				if ((this._Nome != value))
				{
					this.OnNomeChanging(value);
					this.SendPropertyChanging();
					this._Nome = value;
					this.SendPropertyChanged("Nome");
					this.OnNomeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Telefone", DbType="VarChar(15) NOT NULL", CanBeNull=false)]
		public string Telefone
		{
			get
			{
				return this._Telefone;
			}
			set
			{
				if ((this._Telefone != value))
				{
					this.OnTelefoneChanging(value);
					this.SendPropertyChanging();
					this._Telefone = value;
					this.SendPropertyChanged("Telefone");
					this.OnTelefoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CPF", DbType="VarChar(14) NOT NULL", CanBeNull=false)]
		public string CPF
		{
			get
			{
				return this._CPF;
			}
			set
			{
				if ((this._CPF != value))
				{
					this.OnCPFChanging(value);
					this.SendPropertyChanging();
					this._CPF = value;
					this.SendPropertyChanged("CPF");
					this.OnCPFChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="VarChar(150) NOT NULL", CanBeNull=false)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Tipo", DbType="Bit NOT NULL")]
		public bool Tipo
		{
			get
			{
				return this._Tipo;
			}
			set
			{
				if ((this._Tipo != value))
				{
					this.OnTipoChanging(value);
					this.SendPropertyChanging();
					this._Tipo = value;
					this.SendPropertyChanged("Tipo");
					this.OnTipoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Usuario", DbType="VarChar(60)")]
		public string Usuario
		{
			get
			{
				return this._Usuario;
			}
			set
			{
				if ((this._Usuario != value))
				{
					this.OnUsuarioChanging(value);
					this.SendPropertyChanging();
					this._Usuario = value;
					this.SendPropertyChanged("Usuario");
					this.OnUsuarioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Senha", DbType="VarChar(60)")]
		public string Senha
		{
			get
			{
				return this._Senha;
			}
			set
			{
				if ((this._Senha != value))
				{
					this.OnSenhaChanging(value);
					this.SendPropertyChanging();
					this._Senha = value;
					this.SendPropertyChanged("Senha");
					this.OnSenhaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="Bit NOT NULL")]
		public bool Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				if ((this._Status != value))
				{
					this.OnStatusChanging(value);
					this.SendPropertyChanging();
					this._Status = value;
					this.SendPropertyChanged("Status");
					this.OnStatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Notificador_Notificacao", Storage="_Notificacaos", ThisKey="ID", OtherKey="NotificadorID")]
		public EntitySet<Notificacao> Notificacaos
		{
			get
			{
				return this._Notificacaos;
			}
			set
			{
				this._Notificacaos.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Notificacaos(Notificacao entity)
		{
			this.SendPropertyChanging();
			entity.Notificador = this;
		}
		
		private void detach_Notificacaos(Notificacao entity)
		{
			this.SendPropertyChanging();
			entity.Notificador = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Notificando")]
	public partial class Notificando : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Nome;
		
		private string _Telefone;
		
		private string _CPF;
		
		private string _Email;
		
		private bool _Status;
		
		private EntitySet<Notificacao> _Notificacaos;
		
		private EntitySet<Endereco> _Enderecos;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnNomeChanging(string value);
    partial void OnNomeChanged();
    partial void OnTelefoneChanging(string value);
    partial void OnTelefoneChanged();
    partial void OnCPFChanging(string value);
    partial void OnCPFChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnStatusChanging(bool value);
    partial void OnStatusChanged();
    #endregion
		
		public Notificando()
		{
			this._Notificacaos = new EntitySet<Notificacao>(new Action<Notificacao>(this.attach_Notificacaos), new Action<Notificacao>(this.detach_Notificacaos));
			this._Enderecos = new EntitySet<Endereco>(new Action<Endereco>(this.attach_Enderecos), new Action<Endereco>(this.detach_Enderecos));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nome", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string Nome
		{
			get
			{
				return this._Nome;
			}
			set
			{
				if ((this._Nome != value))
				{
					this.OnNomeChanging(value);
					this.SendPropertyChanging();
					this._Nome = value;
					this.SendPropertyChanged("Nome");
					this.OnNomeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Telefone", DbType="VarChar(15)")]
		public string Telefone
		{
			get
			{
				return this._Telefone;
			}
			set
			{
				if ((this._Telefone != value))
				{
					this.OnTelefoneChanging(value);
					this.SendPropertyChanging();
					this._Telefone = value;
					this.SendPropertyChanged("Telefone");
					this.OnTelefoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CPF", DbType="VarChar(14)")]
		public string CPF
		{
			get
			{
				return this._CPF;
			}
			set
			{
				if ((this._CPF != value))
				{
					this.OnCPFChanging(value);
					this.SendPropertyChanging();
					this._CPF = value;
					this.SendPropertyChanged("CPF");
					this.OnCPFChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="VarChar(150) NOT NULL", CanBeNull=false)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="Bit NOT NULL")]
		public bool Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				if ((this._Status != value))
				{
					this.OnStatusChanging(value);
					this.SendPropertyChanging();
					this._Status = value;
					this.SendPropertyChanged("Status");
					this.OnStatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Notificando_Notificacao", Storage="_Notificacaos", ThisKey="ID", OtherKey="NotificandoID")]
		public EntitySet<Notificacao> Notificacaos
		{
			get
			{
				return this._Notificacaos;
			}
			set
			{
				this._Notificacaos.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Notificando_Endereco", Storage="_Enderecos", ThisKey="ID", OtherKey="NotificandoID")]
		public EntitySet<Endereco> Enderecos
		{
			get
			{
				return this._Enderecos;
			}
			set
			{
				this._Enderecos.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Notificacaos(Notificacao entity)
		{
			this.SendPropertyChanging();
			entity.Notificando = this;
		}
		
		private void detach_Notificacaos(Notificacao entity)
		{
			this.SendPropertyChanging();
			entity.Notificando = null;
		}
		
		private void attach_Enderecos(Endereco entity)
		{
			this.SendPropertyChanging();
			entity.Notificando = this;
		}
		
		private void detach_Enderecos(Endereco entity)
		{
			this.SendPropertyChanging();
			entity.Notificando = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Endereco")]
	public partial class Endereco : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Logradouro;
		
		private string _Numero;
		
		private string _Bairro;
		
		private string _Complemento;
		
		private string _Cep;
		
		private string _Cidade;
		
		private string _Estado;
		
		private int _NotificandoID;
		
		private bool _Status;
		
		private EntityRef<Notificando> _Notificando;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnLogradouroChanging(string value);
    partial void OnLogradouroChanged();
    partial void OnNumeroChanging(string value);
    partial void OnNumeroChanged();
    partial void OnBairroChanging(string value);
    partial void OnBairroChanged();
    partial void OnComplementoChanging(string value);
    partial void OnComplementoChanged();
    partial void OnCepChanging(string value);
    partial void OnCepChanged();
    partial void OnCidadeChanging(string value);
    partial void OnCidadeChanged();
    partial void OnEstadoChanging(string value);
    partial void OnEstadoChanged();
    partial void OnNotificandoIDChanging(int value);
    partial void OnNotificandoIDChanged();
    partial void OnStatusChanging(bool value);
    partial void OnStatusChanged();
    #endregion
		
		public Endereco()
		{
			this._Notificando = default(EntityRef<Notificando>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Logradouro", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string Logradouro
		{
			get
			{
				return this._Logradouro;
			}
			set
			{
				if ((this._Logradouro != value))
				{
					this.OnLogradouroChanging(value);
					this.SendPropertyChanging();
					this._Logradouro = value;
					this.SendPropertyChanged("Logradouro");
					this.OnLogradouroChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Numero", DbType="VarChar(6) NOT NULL", CanBeNull=false)]
		public string Numero
		{
			get
			{
				return this._Numero;
			}
			set
			{
				if ((this._Numero != value))
				{
					this.OnNumeroChanging(value);
					this.SendPropertyChanging();
					this._Numero = value;
					this.SendPropertyChanged("Numero");
					this.OnNumeroChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Bairro", DbType="VarChar(60) NOT NULL", CanBeNull=false)]
		public string Bairro
		{
			get
			{
				return this._Bairro;
			}
			set
			{
				if ((this._Bairro != value))
				{
					this.OnBairroChanging(value);
					this.SendPropertyChanging();
					this._Bairro = value;
					this.SendPropertyChanged("Bairro");
					this.OnBairroChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Complemento", DbType="VarChar(100)")]
		public string Complemento
		{
			get
			{
				return this._Complemento;
			}
			set
			{
				if ((this._Complemento != value))
				{
					this.OnComplementoChanging(value);
					this.SendPropertyChanging();
					this._Complemento = value;
					this.SendPropertyChanged("Complemento");
					this.OnComplementoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cep", DbType="VarChar(9) NOT NULL", CanBeNull=false)]
		public string Cep
		{
			get
			{
				return this._Cep;
			}
			set
			{
				if ((this._Cep != value))
				{
					this.OnCepChanging(value);
					this.SendPropertyChanging();
					this._Cep = value;
					this.SendPropertyChanged("Cep");
					this.OnCepChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cidade", DbType="VarChar(60) NOT NULL", CanBeNull=false)]
		public string Cidade
		{
			get
			{
				return this._Cidade;
			}
			set
			{
				if ((this._Cidade != value))
				{
					this.OnCidadeChanging(value);
					this.SendPropertyChanging();
					this._Cidade = value;
					this.SendPropertyChanged("Cidade");
					this.OnCidadeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Estado", DbType="Char(2) NOT NULL", CanBeNull=false)]
		public string Estado
		{
			get
			{
				return this._Estado;
			}
			set
			{
				if ((this._Estado != value))
				{
					this.OnEstadoChanging(value);
					this.SendPropertyChanging();
					this._Estado = value;
					this.SendPropertyChanged("Estado");
					this.OnEstadoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NotificandoID", DbType="Int NOT NULL")]
		public int NotificandoID
		{
			get
			{
				return this._NotificandoID;
			}
			set
			{
				if ((this._NotificandoID != value))
				{
					if (this._Notificando.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnNotificandoIDChanging(value);
					this.SendPropertyChanging();
					this._NotificandoID = value;
					this.SendPropertyChanged("NotificandoID");
					this.OnNotificandoIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="Bit NOT NULL")]
		public bool Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				if ((this._Status != value))
				{
					this.OnStatusChanging(value);
					this.SendPropertyChanging();
					this._Status = value;
					this.SendPropertyChanged("Status");
					this.OnStatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Notificando_Endereco", Storage="_Notificando", ThisKey="NotificandoID", OtherKey="ID", IsForeignKey=true)]
		public Notificando Notificando
		{
			get
			{
				return this._Notificando.Entity;
			}
			set
			{
				Notificando previousValue = this._Notificando.Entity;
				if (((previousValue != value) 
							|| (this._Notificando.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Notificando.Entity = null;
						previousValue.Enderecos.Remove(this);
					}
					this._Notificando.Entity = value;
					if ((value != null))
					{
						value.Enderecos.Add(this);
						this._NotificandoID = value.ID;
					}
					else
					{
						this._NotificandoID = default(int);
					}
					this.SendPropertyChanged("Notificando");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591