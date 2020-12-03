﻿using System;
using System.Drawing;
using System.Linq;

namespace CloudLayouters
{
    public class RectangleLayouter : BaseCloudLayouter
    {
        private Point center;


        public RectangleLayouter(Point center)
        {
            Center = center;
            Location = new Point(center.X / 10, center.Y / 10);
            Name = "Прямоугольное облако";
            Container.AddFreePoint(Location);
        }

        public Point Location { get; private set; }

        public sealed override Point Center
        {
            get => center;
            set
            {
                ClearLayout();
                center = value;
                Location = new Point(center.X / 10, center.Y / 10);
                Container.AddFreePoint(Location);
            }
        }

        public override Rectangle PutNextRectangle(Size rectangleSize)
        {
            foreach (var point in Container.FreePoints.OrderBy(x => Math.Max(x.X, x.Y)))
            {
                var rectangle = new Rectangle(point, rectangleSize);
                if (!CouldPutRectangle(rectangle)) continue;
                AddFreePoints(new Point(point.X + rectangleSize.Width, point.Y));
                AddFreePoints(new Point(point.X, point.Y + rectangleSize.Height));
                Container.AddRectangle(rectangle);
                return rectangle;
            }

            throw new Exception("free points not found:(");
        }

        public override void ClearLayout()
        {
            base.ClearLayout();
            Container.AddFreePoint(Location);
        }

        private void AddFreePoints(Point point)
        {
            Container.AddFreePoint(point);
        }
    }
}