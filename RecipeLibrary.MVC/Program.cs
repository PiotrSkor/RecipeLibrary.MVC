using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

string credentialsJson = @"
{
    
  ""type"": ""service_account"",
  ""project_id"": ""recipelibrary-d8e55"",
  ""private_key_id"": ""1b027b2c691ffc0d5f618ccb8cf44e31ab1a7a0c"",
  ""private_key"": ""-----BEGIN PRIVATE KEY-----\nMIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQDk9Fk8YLINRlxF\n0mDDahryQ06t1heTRGcpjyz1QS62eFf3gGqOzkugJx96SDSweDF6J9Cso2tFsoAF\n/oQqYSdKPFBumt3xaDEE3Lw+ultpYNPDnkzZzToC0DU9qPJ5481mreafC3PbNB8L\nyidg/XiqmFD959hCWrGxeH1FRMs3bZraYoxx/LL3bPIbZSXRhAbwwsygqeViv8P1\nr7BDuO7MYU6rsPZJlwM/6NiKLkc4nM4AVbImtkWesYDsVpEk+krfUQmaVAKtnTXo\nEAIiAGeGINTSH0xjhQwvNgHvdtB2bsma9oOrphLmQY320cTHs+C0a8MGV1Afjl5s\n4XYQO62DAgMBAAECggEAOeM19LgWDJkvl0+7u2zGZ15xNC6fQ1LWKoHSwie64dPH\nmgJT7stl/5YktUwwVjXtfI84iY2//51EFT/mtrhdsL1TMMPjPbg0PKB6z/laR2h9\n4kXR9HeZJUDzVSW0OPFJ654oYyoIHvIsr1RrZHBx4+AjCi9mVFCOAOsP8UWVg+ut\n1QwyRPwhxXHbIfwHRDIniNeA7RaHkn7DZ+UJYwIN9lEueR/kOFwT9fgUFxvAFhgO\ntwTKxh2EvaaJRr//EOcyPSdlmXqDWBa+ODIOZeLw5xKKzIMMa59wggNyisthn9eM\npSw2DrnAinTJ0+QxYuuvEbigi2MlQn4vrwVtiyHbQQKBgQD/Pcxm9oyf1ef/d+mn\nY3uK6Chwh28DDa8ckInQqrt+fIwjcpKhWsSrtM0bonhYhLUm56N7bVByKv7y9GWV\n7qOfNVNLznvkGznC1SUGrUh8DLrgukBefPB0mC2f6z425aSSbmrp7HHG6dbvQEoC\nRGiM0SXCdVJQgHLhJTjf4Q+I0wKBgQDlooyzqYCYGMfV74nP0JxPfhDUuE69+p4s\nf677/klIA3aLEVh2m/ICOtzLmEVw2keNJ8hXPz+m+EwUFQda7JP85IUZZh9Mar5R\nwALTyD/NaLikS5FLywU/qMUDlbIeuOjr/CzAeuOZcnY70zRX1OHuPRI97p43vXV+\n/dqieTdakQKBgQDHAs1L/rKYsXUpmLqi3AtovClDzCV/cPz3Pa9m9qgoMD4oKV4w\n1w//fYJrKJvDEP4Z7oRmaU5PJj0Q/AP1ClOjgDWJJt8sdRntUrmC4jthFZ/kNvSX\nd70Ye8sfJJGmxhkyX0uXRtdTq+H9O9g4ulP2b+CMJWPgBrcL2zTkQpwVJwKBgFEW\nUyTmB9itd3NeAIX3nhqb44maA4QmSVBhTgMByhK51lRJLbnEW3LaIjlqbarqCTYZ\nBC960Bk/uG2m90/uFlvIvg839nlfgBESAm2SWqVIA1tQq9/dst7F07vuUlVy6hza\nkVruigwXVRTPAb66F4Wu3xArgIciSaksLtYMg7VhAoGBAOIU0vbM14+3Kyd1ZqFR\n/Er6e0DbqVwtHdJs9TO3Oc15VZfxVDk1ijucpbQISMIp9laHkreFuSCA0upCDTxJ\nocaf9I2pv2xqNKIFupbUtPnvjdALnfzkjrPW+r5ODwaeu6qq+zCwrDX9kLEVBYhr\nofgWmpLU2IlvA4eEW1ezCUJU\n-----END PRIVATE KEY-----\n"",
  ""client_email"": ""firebase-adminsdk-mm6sn@recipelibrary-d8e55.iam.gserviceaccount.com"",
  ""client_id"": ""100527912278179392917"",
  ""auth_uri"": ""https://accounts.google.com/o/oauth2/auth"",
  ""token_uri"": ""https://oauth2.googleapis.com/token"",
  ""auth_provider_x509_cert_url"": ""https://www.googleapis.com/oauth2/v1/certs"",
  ""client_x509_cert_url"": ""https://www.googleapis.com/robot/v1/metadata/x509/firebase-adminsdk-mm6sn%40recipelibrary-d8e55.iam.gserviceaccount.com"",
  ""universe_domain"": ""googleapis.com""
}";

FirebaseApp.Create(new AppOptions
{
    Credential = GoogleCredential.FromJson(credentialsJson)
});


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Recipe}/{action=Index}/{id?}");

app.Run();
