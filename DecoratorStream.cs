using System;
using System.IO;
using System.Text;
using System.Linq;

public class DecoratorStream : Stream
{
    private Stream stream;
    private string prefix;
    private bool prefixWritten = false;

    public override bool CanSeek { get { return false; } }
    public override bool CanWrite { get { return true; } }
    public override long Length { get; }
    public override long Position { get; set; }
    public override bool CanRead { get { return false; } }

    public DecoratorStream(Stream stream, string prefix) : base()
    {
        this.stream = stream;
        this.prefix = prefix;
    }

    public override void SetLength(long length)
    {
        stream.SetLength(length);
    }

    public override void Write(byte[] bytes, int offset, int count)
    {
        if (!prefixWritten)
        {
            byte[] p = Encoding.UTF8.GetBytes(prefix);
            stream.Write(p, 0, p.Length);
            prefixWritten = true;
        }
        stream.Write(bytes, offset, count);
    }

    public override int Read(byte[] bytes, int offset, int count)
    {
        return stream.Read(bytes, offset, count);
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
        return stream.Seek(offset, origin);
    }

    public override void Flush()
    {
        stream.Flush();
    }

    public static void Main(string[] args)
    {
        byte[] message = new byte[]{0x48, 0x65, 0x6c, 0x6c, 0x6f, 0x2c, 0x20, 0x77, 0x6f, 0x72, 0x6c, 0x64, 0x21};
        using (MemoryStream stream = new MemoryStream())
        {
            using (DecoratorStream decoratorStream = new DecoratorStream(stream, "First line: "))
            {
                decoratorStream.Write(message, 0, message.Length);
                decoratorStream.Write(message, 0, message.Length); // Writing again to test multiple writes
                stream.Position = 0;
                Console.WriteLine(new StreamReader(stream).ReadToEnd());  //should print "First line: Hello, world!Hello, world!"
            }
        }
    }
}
