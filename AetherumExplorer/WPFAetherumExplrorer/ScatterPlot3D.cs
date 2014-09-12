using HelixToolkit.Wpf;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;


namespace TwilightShards.AetherumExplorerW
{
    /// <summary>
    /// This is the control that creates a scatter plot on the main window
    /// </summary>
    public class ScatterPlot3D : ModelVisual3D
    {
        //first, initiate our dependency properties.
        
        /// <summary>
        /// This property is for Points. Note that this is on a different file.
        /// </summary>
        public static readonly DependencyProperty pointsProperty = 
            DependencyProperty.Register("Points", typeof(List<Point3D>), typeof(ScatterPlot3D), 
            new UIPropertyMetadata(null, ModelChanged));

        /// <summary>
        /// This property is for the surface brush
        /// </summary>
        public static readonly DependencyProperty surfaceBrushProperty =
            DependencyProperty.Register("SurfaceBrush", typeof(Brush), typeof(ScatterPlot3D),
                                        new UIPropertyMetadata(null, ModelChanged));
        
        //properties

        /// <summary>
        /// This is model used for the base of the scatter plot.
        /// </summary>
        private readonly ModelVisual3D visualChild;

        /// <summary>
        /// The X interval of the grid
        /// </summary>
        public double IntervalX { get; set; }

        /// <summary>
        /// The Y interval of the grid
        /// </summary>
        public double IntervalY { get; set; }

        /// <summary>
        /// The Z interval of the grid
        /// </summary>
        public double IntervalZ { get; set; }

        /// <summary>
        /// The font size for axis.
        /// </summary>
        public double FontSize { get; set; }

        /// <summary>
        /// The size of the sphere.
        /// </summary>
        public double SphereSize { get; set; }
        
        /// <summary>
        /// The thickness of the axis line
        /// </summary>
        public double LineThickness { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public ScatterPlot3D()
        {
            IntervalX = 1;
            IntervalY = 1;
            IntervalZ = 1;
            FontSize = 0.06;
            SphereSize = 0.49;
            LineThickness = 0.01;

            visualChild = new ModelVisual3D();
            Children.Add(visualChild);
        }

        /// <summary>
        /// The points accessor (Get/Set)
        /// </summary>
        public List<Point3D> Points 
        {
            get { return ((List<Point3D>)GetValue(pointsProperty)); }
            set { SetValue(pointsProperty, value); }
        }

        /// <summary>
        /// The SurfaceBrush accessor (Get/Set)
        /// </summary>
        public Brush SurfaceBrush
        {
            get { return (Brush)GetValue(surfaceBrushProperty); }
            set { SetValue(surfaceBrushProperty, value); } 
        }

        /// <summary>
        /// This tells the system that the model has changed
        /// </summary>
        /// <param name="d">Object - the plot</param>
        /// <param name="e">Event arguments</param>
        public static void ModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ScatterPlot3D)d).UpdateModel();
        }

        /// <summary>
        /// This updates the model by recreating it.
        /// </summary>
        private void UpdateModel()
        {
            visualChild.Content = CreateModel();
        }

        /// <summary>
        /// This function creates the model
        /// </summary>
        /// <returns>A created plot model</returns>
        private Model3D CreateModel()
        {
            var plotModel = new Model3DGroup();
            if (Points == null || Points.Count == 0) return plotModel;

            double minX = Points.Min(p => p.X);
            double maxX = Points.Max(p => p.X);
            double minY = Points.Min(p => p.Y);
            double maxY = Points.Max(p => p.Y);
            double minZ = Points.Min(p => p.Z);
            double maxZ = Points.Max(p => p.Z);
            double minValue = 0;
            double maxValue = 10000;

            var valueRange = maxValue - minValue;

            var scatterMeshBuilder = new MeshBuilder(true, true);

            var oldTCCount = 0;
            for (var i = 0; i < Points.Count; ++i)
            {
                scatterMeshBuilder.AddSphere(Points[i], SphereSize, 4, 4);


                var newTCCount = scatterMeshBuilder.TextureCoordinates.Count;
                oldTCCount = newTCCount;
            }

            var scatterModel = new GeometryModel3D(scatterMeshBuilder.ToMesh(),
                                                   MaterialHelper.CreateMaterial(SurfaceBrush, null, null, 1, 0));
            scatterModel.BackMaterial = scatterModel.Material;

            // create bounding box with axes indications
            var axesMeshBuilder = new MeshBuilder();
            for (double x = minX; x <= maxX; x += IntervalX)
            {
                GeometryModel3D label = TextCreator.CreateTextLabelModel3D(x.ToString(), Brushes.White, true, FontSize,
                                                                           new Point3D(x, minY - FontSize * 2.5, minZ),
                                                                           new Vector3D(1, 0, 0), new Vector3D(0, 1, 0));
                plotModel.Children.Add(label);
            }

            {
                GeometryModel3D label = TextCreator.CreateTextLabelModel3D("X-axis", Brushes.White, true, FontSize,
                                                                           new Point3D((minX + maxX) * 0.5,
                                                                                       minY - FontSize * 6, minZ),
                                                                           new Vector3D(1, 0, 0), new Vector3D(0, 1, 0));
                plotModel.Children.Add(label);
            }

            for (double y = minY; y <= maxY; y += IntervalY)
            {
                GeometryModel3D label = TextCreator.CreateTextLabelModel3D(y.ToString(), Brushes.White, true, FontSize,
                                                                           new Point3D(minX - FontSize * 3, y, minZ),
                                                                           new Vector3D(1, 0, 0), new Vector3D(0, 1, 0));
                plotModel.Children.Add(label);
            }
            {
                GeometryModel3D label = TextCreator.CreateTextLabelModel3D("Y-axis", Brushes.White, true, FontSize,
                                                                           new Point3D(minX - FontSize * 10,
                                                                                       (minY + maxY) * 0.5, minZ),
                                                                           new Vector3D(0, 1, 0), new Vector3D(-1, 0, 0));
                plotModel.Children.Add(label);
            }
            double z0 = (int)(minZ / IntervalZ) * IntervalZ;
            for (double z = z0; z <= maxZ + double.Epsilon; z += IntervalZ)
            {
                GeometryModel3D label = TextCreator.CreateTextLabelModel3D(z.ToString(), Brushes.White, true, FontSize,
                                                                           new Point3D(minX - FontSize * 3, maxY, z),
                                                                           new Vector3D(1, 0, 0), new Vector3D(0, 0, 1));
                plotModel.Children.Add(label);
            }
            {
                GeometryModel3D label = TextCreator.CreateTextLabelModel3D("Z-axis", Brushes.White, true, FontSize,
                                                                           new Point3D(minX - FontSize * 10, maxY,
                                                                                       (minZ + maxZ) * 0.5),
                                                                           new Vector3D(0, 0, 1), new Vector3D(1, 0, 0));
                plotModel.Children.Add(label);
            }

            var bb = new Rect3D(minX, minY, minZ, maxX - minX, maxY - minY, maxZ - minZ);
            axesMeshBuilder.AddBoundingBox(bb, LineThickness);

            var axesModel = new GeometryModel3D(axesMeshBuilder.ToMesh(), Materials.White);

            plotModel.Children.Add(scatterModel);
            plotModel.Children.Add(axesModel);

            return plotModel;
        }

    }
}
