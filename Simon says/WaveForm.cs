using System;

namespace SimonSays
{
    // https://blogs.msdn.microsoft.com/dawate/2009/06/24/intro-to-audio-programming-part-3-synthesizing-simple-wave-audio-using-c/
    // https://blogs.msdn.microsoft.com/dawate/2009/06/25/intro-to-audio-programming-part-4-algorithms-for-different-sound-waves-in-c/
    // http://stackoverflow.com/questions/11768721/play-dynamically-created-simple-sounds-in-c-sharp-without-external-libraries
    // 

    public class WaveForm
    {
    }
    public enum WaveType
    {
        SineWave = 0,
        CosineWave = 1,
        SquareWave = 2,
        SawtoothWave = 3,
        TriangleWave = 4,
        WhiteNoiseWave = 5
    }
    public class WaveHeader
    {
        public string sGroupID; // RIFF
        public uint dwFileLength; // total file length minus 8, which is taken up by RIFF
        public string sRiffType; // always WAVE

        /// <summary>
        /// Initializes a WaveHeader object with the default values.
        /// </summary>
        public WaveHeader()
        {
            dwFileLength = 0;
            sGroupID = "RIFF";
            sRiffType = "WAVE";
        }
    }

    public class WaveFormatChunk
    {
        public string sChunkID;         // Four bytes: "fmt "
        public uint dwChunkSize;        // Length of header in bytes
        public ushort wFormatTag;       // 1 (MS PCM)
        public ushort wChannels;        // Number of channels
        public uint dwSamplesPerSec;    // Frequency of the audio in Hz... 44100
        public uint dwAvgBytesPerSec;   // for estimating RAM allocation
        public ushort wBlockAlign;      // sample frame size, in bytes
        public ushort wBitsPerSample;    // bits per sample

        /// <summary>
        /// Initializes a format chunk with the following properties:
        /// Sample rate: 44100 Hz
        /// Channels: Stereo
        /// Bit depth: 16-bit
        /// </summary>
        public WaveFormatChunk()
        {
            sChunkID = "fmt ";
            dwChunkSize = 16;
            wFormatTag = 1;
            wChannels = 2;
            dwSamplesPerSec = 44100;
            wBitsPerSample = 16;
            wBlockAlign = (ushort)(wChannels * (wBitsPerSample / 8));
            dwAvgBytesPerSec = dwSamplesPerSec * wBlockAlign;
        }
    }

    public class WaveDataChunk
    {
        public string sChunkID;     // "data"
        public uint dwChunkSize;    // Length of header in bytes
        public short[] shortArray;  // 16-bit audio  If you want to change to 8-bit audio, use an array of bytes. If you want to use 32-bit audio, use an array of floats.

        /// <summary>
        /// Initializes a new data chunk with default values.
        /// </summary>
        public WaveDataChunk()
        {
            shortArray = new short[0];
            dwChunkSize = 0;
            sChunkID = "data";
        }
    }

    public class WaveGenerator
    {
        // Header, Format, Data chunks
        WaveHeader header;
        WaveFormatChunk format;
        WaveDataChunk data;
        System.IO.MemoryStream audioStream;

        // Variables to construct the waveform
        uint numSamples;
        int amplitude;
        int msFade;
        double frequency;
        double tau;

        public WaveGenerator()
        {
            // Init chunks
            header = new WaveHeader();
            format = new WaveFormatChunk();
            data = new WaveDataChunk();

            // Initializes the audio stream
            audioStream = new System.IO.MemoryStream();
        }

        /// <snip>
        public WaveGenerator(double freq, int msDuration, WaveType type, short volume = 16383, int milisecondsFade = 30)
            :this()
        {

            // Other data
                // Number of samples = sample rate * channels * bytes per sample
                numSamples = (uint)(format.dwSamplesPerSec * format.wChannels * msDuration/ 1000);

                // Initialize the 16-bit array
                data.shortArray = new short[numSamples];

                amplitude = 32760;  // Max amplitude for 16-bit audio
                amplitude = Math.Abs(volume);
                frequency = freq;   // Concert A: 440Hz
                msFade = milisecondsFade;

            // The "angle" used in the function, adjusted for the number of channels and sample rate.
            // This value is like the period of the wave.
            tau = (Math.PI * 2 * frequency) / (format.dwSamplesPerSec * format.wChannels);
            //t = (Math.PI * 2 * frequency) / (numSamples);

            // Fill the data array with sample data
            switch (type)
            {
                case WaveType.SineWave:
                    GenerateSineWave();
                    break;
                case WaveType.CosineWave:
                    GenerateCosineWave();
                    break;
                case WaveType.SquareWave:
                    GenerateSquareWave();
                    break;
                case WaveType.SawtoothWave:
                    GenerateSawToothWave();
                    break;
                case WaveType.TriangleWave:
                    GenerateTriangleWave();
                    break;
                case WaveType.WhiteNoiseWave:
                    GenerateWhiteNoiseWave();
                    break;
            }

            // Calculate data chunk size in bytes
            data.dwChunkSize = (uint)(data.shortArray.Length * (format.wBitsPerSample / 8));

        }

        /// <summary>
        /// Generates a wave sound
        /// </summary>
        /// <param name="freq">Frequency in Hertz</param>
        /// <param name="msDuration">Duration in ms of the wave</param>
        /// <param name="type">Type of the wave</param>
        /// <param name="volume">Volume</param>
        /// <param name="milisecondsFade">Fading time</param>
        public void GenerateWave(double freq, int msDuration, WaveType type, short volume = 16383, int milisecondsFade = 30)
        {
            // Other data
            // Number of samples = sample rate * channels * bytes per sample
            numSamples = (uint)(format.dwSamplesPerSec * format.wChannels * msDuration / 1000);

            // Initialize the 16-bit array
            data.shortArray = new short[numSamples];

            //amplitude = 32760;  // Max amplitude for 16-bit audio
            amplitude = Math.Abs(volume);
            frequency = freq;
            msFade = milisecondsFade;

            // The "angle" used in the function, adjusted for the number of channels and sample rate.
            // This value is like the period of the wave.
            tau = (Math.PI * 2 * frequency) / (format.dwSamplesPerSec * format.wChannels);
            //t = (Math.PI * 2 * frequency) / (numSamples);

            // Fill the data array with sample data
            switch (type)
            {
                case WaveType.SineWave:
                    GenerateSineWave();
                    break;
                case WaveType.CosineWave:
                    GenerateCosineWave();
                    break;
                case WaveType.SquareWave:
                    GenerateSquareWave();
                    break;
                case WaveType.SawtoothWave:
                    GenerateSawToothWave();
                    break;
                case WaveType.TriangleWave:
                    GenerateTriangleWave();
                    break;
                case WaveType.WhiteNoiseWave:
                    GenerateWhiteNoiseWave();
                    break;
            }

            // Calculate data chunk size in bytes
            data.dwChunkSize = (uint)(data.shortArray.Length * (format.wBitsPerSample / 8));
        }

        /// <summary>
        /// Generates the audio stream
        /// </summary>
        public void GenerateAudioStream()
        {
            // write data to a MemoryStream with BinaryWriter
            System.IO.BinaryWriter writer = new System.IO.BinaryWriter(audioStream);

            // Write the header
            writer.Write(header.sGroupID.ToCharArray());
            writer.Write(header.dwFileLength);
            writer.Write(header.sRiffType.ToCharArray());

            // Write the format chunk
            writer.Write(format.sChunkID.ToCharArray());
            writer.Write(format.dwChunkSize);
            writer.Write(format.wFormatTag);
            writer.Write(format.wChannels);
            writer.Write(format.dwSamplesPerSec);
            writer.Write(format.dwAvgBytesPerSec);
            writer.Write(format.wBlockAlign);
            writer.Write(format.wBitsPerSample);

            // Write the data chunk
            writer.Write(data.sChunkID.ToCharArray());
            writer.Write(data.dwChunkSize);
            foreach (short dataPoint in data.shortArray)
            {
                writer.Write(dataPoint);
            }
            writer.Seek(4, System.IO.SeekOrigin.Begin);
            uint filesize = (uint)writer.BaseStream.Length;
            writer.Write(filesize - 8);

            // End writing the audio stream
            writer.Close();
            audioStream.Close();
        }

        public void PlaySound()
        {
            // write data to a MemoryStream with BinaryWriter
            // System.IO.MemoryStream audioStream = new System.IO.MemoryStream();
            //audioStream = new System.IO.MemoryStream();
            System.IO.BinaryWriter writer = new System.IO.BinaryWriter(audioStream);

            // Write the header
            writer.Write(header.sGroupID.ToCharArray());
            writer.Write(header.dwFileLength);
            writer.Write(header.sRiffType.ToCharArray());

            // Write the format chunk
            writer.Write(format.sChunkID.ToCharArray());
            writer.Write(format.dwChunkSize);
            writer.Write(format.wFormatTag);
            writer.Write(format.wChannels);
            writer.Write(format.dwSamplesPerSec);
            writer.Write(format.dwAvgBytesPerSec);
            writer.Write(format.wBlockAlign);
            writer.Write(format.wBitsPerSample);

            // Write the data chunk
            writer.Write(data.sChunkID.ToCharArray());
            writer.Write(data.dwChunkSize);
            foreach (short dataPoint in data.shortArray)
            {
                writer.Write(dataPoint);
            }
            writer.Seek(4, System.IO.SeekOrigin.Begin);
            uint filesize = (uint)writer.BaseStream.Length;
            writer.Write(filesize - 8);

            System.Media.SoundPlayer player = new System.Media.SoundPlayer(audioStream);
            if (player != null)
            {
                player.Stream.Seek(0, System.IO.SeekOrigin.Begin); // rewind stream
                player.Play();
            }
            writer.Close();
            audioStream.Close();
        }

        public void Save(string filePath)
        {
            // Create a file (it always overwrites)
            System.IO.FileStream fileStream = new System.IO.FileStream(filePath, System.IO.FileMode.Create);

            // Use BinaryWriter to write the bytes to the file
            System.IO.BinaryWriter writer = new System.IO.BinaryWriter(fileStream);
   
            // Write the header
            writer.Write(header.sGroupID.ToCharArray());
            writer.Write(header.dwFileLength);
            writer.Write(header.sRiffType.ToCharArray());
  
            // Write the format chunk
            writer.Write(format.sChunkID.ToCharArray());
            writer.Write(format.dwChunkSize);
            writer.Write(format.wFormatTag);
            writer.Write(format.wChannels);
            writer.Write(format.dwSamplesPerSec);
            writer.Write(format.dwAvgBytesPerSec);
            writer.Write(format.wBlockAlign);
            writer.Write(format.wBitsPerSample);
  
            // Write the data chunk
            writer.Write(data.sChunkID.ToCharArray());
            writer.Write(data.dwChunkSize);
            foreach (short dataPoint in data.shortArray)
            {
                writer.Write(dataPoint);
            }

            writer.Seek(4, System.IO.SeekOrigin.Begin);
            uint filesize = (uint)writer.BaseStream.Length;
            writer.Write(filesize - 8);
  
            // Clean up
            writer.Close();
            fileStream.Close();

            return;
        }

        private void GenerateSineWave()
        {
            double tempSample;
            uint fadeIn = (uint)(format.dwSamplesPerSec * format.wChannels * msFade / 1000);
            uint fadeOut = numSamples - fadeIn;
            for (uint i = 0; i < numSamples; i += format.wChannels)
            {
                if (i < fadeIn)
                {
                    //tempSample = (i / (double)fadeIn) * amplitude * Math.Sin(tau * i);
                    tempSample = EaseInOutCubic(i, fadeIn, 0, 1) * amplitude * Math.Sin(tau * i);
                }
                else if (i > fadeOut)
                {
                    //tempSample = ((numSamples - i) / (double)fadeIn) * amplitude * Math.Sin(tau * i);
                    tempSample = (1 - EaseInOutCubic(i - fadeOut, fadeIn, 0, 1)) * amplitude * Math.Sin(tau * i);
                }
                else
                {
                    tempSample = amplitude * Math.Sin(tau * i);
                }

                // Fill with a simple sine wave at max amplitude
                for (int channel = 0; channel < format.wChannels; channel++)
                {
                    data.shortArray[i + channel] = Convert.ToInt16(tempSample);
                }
            }

            return;
        }

        private void GenerateCosineWave()
        {
            double tempSample;

            for (int i = 0; i < numSamples; i += format.wChannels)
            {
                tempSample = amplitude * Math.Cos(tau * i);
                // Fill with a simple cosine wave at max amplitude
                for (int channel = 0; channel < format.wChannels; channel++)
                {
                    data.shortArray[i + channel] = Convert.ToInt16(tempSample);
                }
            }

            return;
        }

        private void GenerateSquareWave()
        {
            double tempSample;

            for (int i = 0; i < numSamples - 1; i += format.wChannels)
            {
                tempSample = amplitude * Math.Sign(Math.Sin(tau * i));

                for (int channel = 0; channel < format.wChannels; channel++)
                {
                    data.shortArray[i+channel] = Convert.ToInt16(tempSample);
                }
            }
            return;
        }

        private void GenerateSawToothWave()
        {
            // Determine the number of samples per wavelength
            int samplesPerWavelength = Convert.ToInt32(format.dwSamplesPerSec / (frequency / format.wChannels));

            // Determine the amplitude step for consecutive samples
            short ampStep = Convert.ToInt16((amplitude * 2) / samplesPerWavelength);

            // Temporary sample value, added to as we go through the loop
            short tempSample = (short)-amplitude;

            // Total number of samples written so we know when to stop
            int totalSamplesWritten = 0;

            while (totalSamplesWritten < numSamples)
            {
                tempSample = (short)-amplitude;

                for (uint i = 0; i < samplesPerWavelength && totalSamplesWritten < numSamples; i++)
                {
                    tempSample += ampStep;

                    for (int channel = 0; channel < format.wChannels; channel++)
                    {
                        data.shortArray[totalSamplesWritten] = tempSample;
                        totalSamplesWritten++;
                    }
                }
            }
        }

        private void GenerateTriangleWave()
        {
            // Determine the number of samples per wavelength
            int samplesPerWavelength = Convert.ToInt32(format.dwSamplesPerSec / (frequency / format.wChannels));

            // Determine the amplitude step for consecutive samples
            short ampStep = Convert.ToInt16((amplitude * 2) / samplesPerWavelength);

            // Temporary sample value, added to as we go through the loop
            short tempSample = (short)-amplitude;

            for (int i = 0; i < numSamples - 1; i += format.wChannels)
            {
                for (int channel = 0; channel < format.wChannels; channel++)
                {
                    // Negate ampstep whenever it hits the amplitude boundary
                    if (Math.Abs(tempSample) > amplitude)
                        ampStep = (short)-ampStep;

                    tempSample += ampStep;
                    data.shortArray[i + channel] = tempSample;
                }
            }
        }

        private void GenerateWhiteNoiseWave()
        {
            Random rnd = new Random();
            short randomValue = 0;

            for (int i = 0; i < numSamples; i++)
            {
                randomValue = Convert.ToInt16(rnd.Next(-amplitude, amplitude));
                data.shortArray[i] = randomValue;
            }
        }

        public static void PlayBeep(ushort frequency, int msDuration, UInt16 volume = 16383)
        {
            System.IO.MemoryStream mStrm = new System.IO.MemoryStream();
            System.IO.BinaryWriter writer = new System.IO.BinaryWriter(mStrm);

            const double TAU = 2 * Math.PI;
            int formatChunkSize = 16;
            int headerSize = 8;
            short formatType = 1;
            short tracks = 1;
            int samplesPerSecond = 44100;
            short bitsPerSample = 16;
            short frameSize = (short)(tracks * ((bitsPerSample + 7) / 8));
            int bytesPerSecond = samplesPerSecond * frameSize;
            int waveSize = 4;
            int samples = (int)((decimal)samplesPerSecond * msDuration / 1000);
            int dataChunkSize = samples * frameSize;
            int fileSize = waveSize + headerSize + formatChunkSize + headerSize + dataChunkSize;
            // var encoding = new System.Text.UTF8Encoding();
            writer.Write(0x46464952); // = encoding.GetBytes("RIFF")
            writer.Write(fileSize);
            writer.Write(0x45564157); // = encoding.GetBytes("WAVE")
            writer.Write(0x20746D66); // = encoding.GetBytes("fmt ")
            writer.Write(formatChunkSize);
            writer.Write(formatType);
            writer.Write(tracks);
            writer.Write(samplesPerSecond);
            writer.Write(bytesPerSecond);
            writer.Write(frameSize);
            writer.Write(bitsPerSample);
            writer.Write(0x61746164); // = encoding.GetBytes("data")
            writer.Write(dataChunkSize);
            {
                double theta = frequency * TAU / (double)samplesPerSecond;
                // 'volume' is UInt16 with range 0 thru Uint16.MaxValue ( = 65 535)
                // we need 'amp' to have the range of 0 thru Int16.MaxValue ( = 32 767)
                double amp = volume >> 2; // so we simply set amp = volume / 2
                for (int step = 0; step < samples; step++)
                {
                    short s = (short)(amp * Math.Sin(theta * (double)step));
                    writer.Write(s);
                }
            }

            mStrm.Seek(0, System.IO.SeekOrigin.Begin);
            new System.Media.SoundPlayer(mStrm).Play();
            writer.Close();
            mStrm.Close();
        }

        /// <summary>
        /// Linear tween equation
        /// </summary>
        /// <param name="nTimeCurrent">The current time (starting at zero) we are in and want to calculate for</param>
        /// <param name="nTimeDuration">The easing/tween duration</param>
        /// <param name="nStartingValue">The starting value at the beginning of the easing/tween</param>
        /// <param name="nEndingValue">The starting value at the ending of the easing/tween</param>
        /// <returns>The linear factor between nStartingValue and nEndingValue</returns>
        private double LinearTween (uint nTimeCurrent, uint nTimeDuration, uint nStartingValue, uint nEndingValue)
        {
            return nEndingValue * nTimeCurrent / nTimeDuration + nStartingValue;
        }


        /// <summary>
        /// Easing-in cubic equation
        /// </summary>
        /// <param name="nTimeCurrent">The current time (starting at zero) we are in and want to calculate for</param>
        /// <param name="nTimeDuration">The easing duration</param>
        /// <param name="nStartingValue">The starting value at the beginning of the easing</param>
        /// <param name="nEndingValue">The starting value at the ending of the easing</param>
        /// <returns>The cubic easing-in factor between nStartingValue and nEndingValue</returns>
        private double EaseInCubic (uint nTimeCurrent, uint nTimeDuration, uint nStartingValue, uint nEndingValue)
        {
            double dTime = (double)nTimeCurrent / nTimeDuration;
            return nEndingValue * dTime * dTime * dTime + nStartingValue;
        }

        /// <summary>
        /// Easing-out cubic equation
        /// </summary>
        /// <param name="nTimeCurrent">The current time (starting at zero) we are in and want to calculate for</param>
        /// <param name="nTimeDuration">The easing duration</param>
        /// <param name="nStartingValue">The starting value at the beginning of the easing</param>
        /// <param name="nEndingValue">The starting value at the ending of the easing</param>
        /// <returns>The cubic easing-out factor between nStartingValue and nEndingValue</returns>
        private double EaseOutCubic(uint nTimeCurrent, uint nTimeDuration, uint nStartingValue, uint nEndingValue)
        {
            double dTime = (double)nTimeCurrent / nTimeDuration;
            dTime--;
            return nEndingValue * (dTime * dTime * dTime + 1) + nStartingValue;

        }

        /// <summary>
        /// Easing-in-out cubic equation
        /// </summary>
        /// <param name="nTimeCurrent">The current time (starting at zero) we are in and want to calculate for</param>
        /// <param name="nTimeDuration">The easing duration</param>
        /// <param name="nStartingValue">The starting value at the beginning of the easing</param>
        /// <param name="nEndingValue">The starting value at the ending of the easing</param>
        /// <returns>The cubic easing-in-out factor between nStartingValue and nEndingValue</returns>
        private double EaseInOutCubic(uint nTimeCurrent, uint nTimeDuration, uint nStartingValue, uint nEndingValue)
        {
            double dTime = (double)nTimeCurrent / nTimeDuration;
            dTime *= 2;
            if (dTime < 1) return (nEndingValue / 2.0) * dTime * dTime * dTime + nStartingValue;
            dTime -= 2;
            return (nEndingValue / 2.0) * (dTime * dTime * dTime + 2) + nStartingValue;
        }

        /// <summary>
        /// Easing-in quadratic equation
        /// </summary>
        /// <param name="nTimeCurrent">The current time (starting at zero) we are in and want to calculate for</param>
        /// <param name="nTimeDuration">The easing duration</param>
        /// <param name="nStartingValue">The starting value at the beginning of the easing</param>
        /// <param name="nEndingValue">The starting value at the ending of the easing</param>
        /// <returns>The quadratic easing-in factor between nStartingValue and nEndingValue</returns>
        private double EaseInQuad (uint nTimeCurrent, uint nTimeDuration, uint nStartingValue, uint nEndingValue)
        {
            double dTime = (double)nTimeCurrent / nTimeDuration;
            return nEndingValue * dTime * dTime + nStartingValue;
        }

        /// <summary>
        /// Easing-out quadratic equation
        /// </summary>
        /// <param name="nTimeCurrent">The current time (starting at zero) we are in and want to calculate for</param>
        /// <param name="nTimeDuration">The easing duration</param>
        /// <param name="nStartingValue">The starting value at the beginning of the easing</param>
        /// <param name="nEndingValue">The starting value at the ending of the easing</param>
        /// <returns>The quadratic easing-out factor between nStartingValue and nEndingValue</returns>
        private double EaseOutQuad (uint nTimeCurrent, uint nTimeDuration, uint nStartingValue, uint nEndingValue)
        {
            double dTime = (double)nTimeCurrent / nTimeDuration;
            return -nEndingValue * dTime * (dTime - 2) + nStartingValue;
        }

        private double EaseInOutQuad(uint nTimeCurrent, uint nTimeDuration, uint nStartingValue, uint nEndingValue)
        {
            double dTime = (double)nTimeCurrent / nTimeDuration;
            dTime *= 2;
            if (dTime < 1) return nEndingValue / 2.0 * dTime * dTime + nStartingValue;
            dTime--;
            return -nEndingValue / 2.0 * (dTime * (dTime - 2) - 1) + nStartingValue;
        }

        // http://gizma.com/easing/#cub3
        // http://joshondesign.com/2013/03/01/improvedEasingEquations

    }

}
