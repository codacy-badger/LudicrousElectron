﻿using System;
using System.Collections.Generic;
using System.Drawing;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;


using LudicrousElectron.Engine.Graphics.Textures;

namespace LudicrousElectron.Engine.Graphics
{
	public class Material
	{
		public string Name = string.Empty;

        public TextureInfo.TextureFormats DefaultDiffuseFormat = TextureInfo.TextureFormats.TextureMap;

		public string DiffuseName = string.Empty;
		internal TextureInfo _DiffuseTexture = null;
		public TextureInfo DiffuseTexture
		{
			get
			{
                if (string.IsNullOrEmpty(DiffuseName))
                    return null;

				if (_DiffuseTexture == null)
					_DiffuseTexture = TextureManager.GetTexture(DiffuseName, null, DefaultDiffuseFormat);
				return _DiffuseTexture;
			}
		}

		public Color DiffuseColor = Color.White;

		public string NormalMapName = string.Empty;
		internal TextureInfo _NormalMapTexture = null;
		public TextureInfo NormalMapTexture
		{
			get
			{
               if (string.IsNullOrEmpty(NormalMapName))
                        return null;

                if (_NormalMapTexture == null)
					_NormalMapTexture = TextureManager.GetTexture(NormalMapName);
				return _NormalMapTexture;
			}
		}

		public string SpecularMapName = string.Empty;
		internal TextureInfo _SpecularTexture = null;
		public TextureInfo SpecularTexture
		{
			get
			{
                if (string.IsNullOrEmpty(SpecularMapName))
                        return null;

                if (_SpecularTexture == null)
					_SpecularTexture = TextureManager.GetTexture(SpecularMapName);
				return _SpecularTexture;
			}
		}
		public Color SpecularColor = Color.Transparent;

		public string EmissionMapName = string.Empty;
		internal TextureInfo _EmissionTexture = null;
		public TextureInfo EmissionTexture
		{
			get
            {
                if (string.IsNullOrEmpty(EmissionMapName))
                        return null;

                if (_EmissionTexture == null)
					_EmissionTexture = TextureManager.GetTexture(EmissionMapName);
				return _EmissionTexture;
			}
		}
		public Color EmissionColor = Color.Transparent;

		public static readonly Material Default = new Material();


		public Material() { }

		public Material(Color color, TextureInfo texture)
		{
			DiffuseName = texture.RelativeName;
			DiffuseColor = color;
			_DiffuseTexture = texture;
		}

		public void Bind()
		{
			// load shaders here when we have them

			// GL 1.X pipeline
			if (DiffuseName == string.Empty)
				GL.Disable(EnableCap.Texture2D);
			else
			{
				GL.Enable(EnableCap.Texture2D);

				if (DiffuseTexture == null)
				{
					DiffuseName = string.Empty;
					GL.Disable(EnableCap.Texture2D);
				}
				else
					DiffuseTexture.Bind();
			}

			GL.Color4(DiffuseColor);
		}
	}
}
