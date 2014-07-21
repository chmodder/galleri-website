using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;

public partial class admin_opretBillede : System.Web.UI.Page
{
    protected void tilbageBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("visBilleder.aspx?id=" + Request.QueryString["id"]);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //SqlConnection conn = new SqlConnection();
        //conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

        //SqlCommand cmd = new SqlCommand();
        //cmd.Connection = conn;
        //cmd.CommandText = "SELECT * FROM Media";

        //conn.Open();
        //SqlDataReader reader = cmd.ExecuteReader();

        //Repeater_images.DataSource = reader;
        //Repeater_images.DataBind();

        //conn.Close();

    }

    #region simpel upload til mappe og database

    protected void albumPicker_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button_upload_Click(object sender, EventArgs e)
    {
        try
        {
            // Upload originalen til mappen /images/upload/original/
            FileUpload_img.SaveAs(Server.MapPath("/upload/originals/") + FileUpload_img.FileName);

            // Kald Metoden MakeThumbs, som laver en Reisze af originalen til 768px i bredden og uploader den til originalsResized mappen 
            MakeThumb(FileUpload_img.FileName, "/upload/originals/", 768, "/upload/originalsResized/");

            // Kald Metoden MakeThumbs, som laver en Thumbnail og uploader den til Thumbs mappen
            MakeThumb(FileUpload_img.FileName, "/upload/originals/", 120, "/upload/thumbs/");

            // Insert i databasen
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO Billeder (imgnavn, thumbnavn, alt, fkAlbumId) VALUES (@imgnavn, @thumbnavn, @alt, @albumid)";
            cmd.Parameters.Add("@imgnavn", SqlDbType.NVarChar).Value = FileUpload_img.FileName;
            cmd.Parameters.Add("@thumbnavn", SqlDbType.NVarChar).Value = FileUpload_img.FileName;
            cmd.Parameters.Add("@albumid", SqlDbType.Int).Value = albumPicker.SelectedValue;
            cmd.Parameters.Add("@alt", SqlDbType.NText).Value = billedTekst.Text;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            // Besked om at billedet er gemt
            Label_besked.Text = "<div class='span6 offset1'><div class='alert alert-success'>Billedet blev gemt</div></div>";

            billedTekst.Text = "Skriv billedtekst her";

            Page_Load(null, null);
        }
        catch (Exception)
        {
            Label_besked.Text = "<div class='span6 offset1'><div class='alert alert-success'>Billedet blev <b>ikke</b> gemt</div></div>";


        }
    }

    #endregion

    #region Metoden MakeThumb
    /// <summary>
    /// Opret et Thumb, baseret på en fil og en mappe
    /// </summary>
    /// <param name="Filename">Hvad hedder filen</param>
    /// <param name="UploadFolder">Hvor er den uploadet til</param>
    private void MakeThumb(string Filename, string UploadFolder, int bredde, string thumbuploadfolder)
    {
        // find det uploadede image
        System.Drawing.Image OriginalImg = System.Drawing.Image.FromFile(Server.MapPath("~/") + UploadFolder + Filename);

        // find højde og bredde på image
        int originalWidth = OriginalImg.Width;
        int originalHeight = OriginalImg.Height;

        // bestem den nye bredde på det thumbnail som skal laves
        int newWidth = bredde;

        // beregn den nye højde på thumbnailbilledet
        double ratio = newWidth / (double)originalWidth;
        int newHeight = Convert.ToInt32(ratio * originalHeight);


        Bitmap Thumb = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);
        Thumb.SetResolution(OriginalImg.HorizontalResolution, OriginalImg.VerticalResolution);

        // Hvis billedet indeholder nogen form for transperans 
        //(mere eller mindre gennemsigtig, eller en gennemsigtig baggrund) bliver det gjort her
        Thumb.MakeTransparent();


        // opret det nye billede
        Graphics ThumbMaker = Graphics.FromImage(Thumb);
        ThumbMaker.InterpolationMode = InterpolationMode.HighQualityBicubic;

        ThumbMaker.DrawImage(OriginalImg,
            new Rectangle(0, 0, newWidth, newHeight),
            new Rectangle(0, 0, originalWidth, originalHeight),
            GraphicsUnit.Pixel);

        // encoding
        ImageCodecInfo encoder;
        string fileExt = System.IO.Path.GetExtension(Filename);
        switch (fileExt)
        {
            case ".png":
                encoder = GetEncoderInfo("image/png");
                break;

            case ".gif":
                encoder = GetEncoderInfo("image/gif");
                break;

            default:
                // default til JPG 
                encoder = GetEncoderInfo("image/jpeg");
                break;
        }

        EncoderParameters encoderParameters = new EncoderParameters(1);
        encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, 100L);

        // gem thumbnail i mappen /Images/Uploads/Thumbs/
        Thumb.Save(Server.MapPath("~") + thumbuploadfolder + Filename, encoder, encoderParameters);

        // Fjern originalbilledet, thumbnail mm, fra computerhukommelsen
        OriginalImg.Dispose();
        ThumbMaker.Dispose();
        Thumb.Dispose();

    }

    #region encoding metode

    private static ImageCodecInfo GetEncoderInfo(String mimeType)
    {
        ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
        for (int i = 0; i < encoders.Length; i++)
        {
            if (encoders[i].MimeType == mimeType)
            {
                return encoders[i];
            }
        }
        return null;
    }
    
}
    #endregion

    #endregion

    