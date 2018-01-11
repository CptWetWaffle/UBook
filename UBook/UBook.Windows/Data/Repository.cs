namespace UBook.Data
{
   //public class Repository
   // {
   //     #region Singleton usage: Repository.Instance
   //     private static readonly Repository MInstance = new Repository();
   //     private Data mData =  new Data();
   //
   //     static Repository()
   //     {
   //     }
   //
   //     private Repository()
   //     {
   //     }
   //
   //     public Data GetData
   //     {
   //         get { return Mdata; }
   //         set { Mdata = value; }
   //     }
   //
   //     public static Repository Instance { get { return MInstance; } }
   //
   //     #endregion
   //
   //
   //
   //    public void Load( string aConnection )
   //     {
   //         var formatter = new XmlSerializer( typeof(Data), GetTypes() );
   //         using ( Stream stream = File.OpenRead( aConnection ) )
   //         {
   //             mData = formatter.Deserialize( stream ) as Data;
   //         }
   //     }
   //
   //    
   //     public void Save( string aConnection )
   //     {
   //         var formatter = new XmlSerializer( typeof (Data));
   //         using ( Stream stream = new FileStream( aConnection, FileMode.Create, FileAccess.Write, FileShare.None ) )
   //         {
   //             formatter.Serialize( stream, mData );
   //         }
   //         
   //     }
   //
   // }
   // }
}
