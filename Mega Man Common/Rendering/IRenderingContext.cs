﻿using MegaMan.Common.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MegaMan.Common.Rendering
{
    public interface IRenderingContext
    {
        IResourceImage LoadResource(FilePath texturePath, String paletteName = null);
        IResourceImage CreateColorResource(Color color);
        void Begin();
        void End();
        void EnableLayer(Int32 layer);
        void DisableLayer(Int32 layer);
        bool IsLayerEnabled(Int32 layer);
        void SetOpacity(float opacity);
        float GetOpacity();

        void Draw(IResourceImage resource, Int32 layer, Point position, Rectangle? sourceRect = null, bool flipHorizontal = false, bool flipVertical = false);
    }
}
