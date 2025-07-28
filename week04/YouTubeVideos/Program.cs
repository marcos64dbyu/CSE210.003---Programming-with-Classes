using System;
using YouTubeVideos;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("CAÍDA de roles ENTRY LEVEL en TECH: ¿QUÉ está PASANDO?", "Patri Juane", 1648);
        video1.AddComment(new Comment("cl3on482", "Al principio estaba pensando que no me iba a gustar tu video. Pero está buenísimo."));
        video1.AddComment(new Comment("juanM1ta", "Fabuloso video, lo malo es que yo que no tengo ni me dan la experiencia me hunde bastante este tema."));
        video1.AddComment(new Comment("Rafab-z7k8b", "Excelente tema!"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Las Verdaderas Consecuencias del Cambio Climático", "QuantumFracture", 1244);
        video2.AddComment(new Comment("El_Girasol_Fachero", "Tanto que se habla de este tema que ya hacía falta un video sobre el cambio climático en Quantum Fracture... excelente entrega!!!! Saludos Crespo"));
        video2.AddComment(new Comment("sergioandres3864", "Las frase que dice \"las ganancias son privadas, pero las pérdidas públicas\" siempre va a tener sentido en cualquier aspecto de la sociedad."));
        video2.AddComment(new Comment("FJ23", "Es triste que todas las historias que se cuentan están ya ocurriendo"));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("When We Almost Nuked the Moon", "El Robot de Platón", 1454);
        video3.AddComment(new Comment("armandovalencia944", "Gracias por compartir Valentina, siempre un placer ver tus videos"));
        video3.AddComment(new Comment("titofunes4547", "Felicitaciones!, Hermoso programa y bellísimo arte en el cuadro!, Bendiciones!"));
        video3.AddComment(new Comment("yeisonposadaamariles1513", "Gracias por este lindo video y su reflexión final "));
        videos.Add(video3);

        // Display all videos and their comments
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}