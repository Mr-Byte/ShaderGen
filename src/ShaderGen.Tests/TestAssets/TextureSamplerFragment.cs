﻿using ShaderGen;
using System.Numerics;
using static ShaderGen.ShaderBuiltins;

namespace TestShaders
{
    public class TextureSamplerFragment
    {
        public struct FragmentInput
        {
            [VertexSemantic(SemanticType.Position)]
            public Vector4 Position;
            [VertexSemantic(SemanticType.TextureCoordinate)]
            public Vector2 TextureCoordinate;
        }

        [Resource(0)]
        public Texture2DResource Tex2D;

        [Resource(1)]
        public TextureCubeResource TexCube;

        [Resource(2)]
        public SamplerResource Sampler;

        [FragmentShader]
        public Vector4 FS(FragmentInput input)
        {
            Vector4 cubeSample = Sample(TexCube, Sampler, new Vector3(1, 2, 3));
            return Sample(Tex2D, Sampler, input.TextureCoordinate);
        }
    }
}
