using System;
using Xamarin.Forms;

namespace ExploreChildSizes
{
    class OpenLabel : Label
    {
        static readonly BindablePropertyKey ConstraintKey =
            BindableProperty.CreateReadOnly<OpenLabel, Size>
                (openLabel => openLabel.Constraint,
                new Size());

        public static readonly BindableProperty ConstraintProperty = 
            ConstraintKey.BindableProperty;

        static readonly BindablePropertyKey SizeRequestKey =
            BindableProperty.CreateReadOnly<OpenLabel, SizeRequest>
                (openLabel => openLabel.SizeRequest,
                new SizeRequest());

        public static readonly BindableProperty SizeRequestProperty = 
            SizeRequestKey.BindableProperty;

        static readonly BindablePropertyKey ElementBoundsKey =
            BindableProperty.CreateReadOnly<OpenLabel, Rectangle>
                (openLabel => openLabel.ElementBounds,
                new Rectangle());

        public static readonly BindableProperty ElementBoundsProperty = 
            ElementBoundsKey.BindableProperty;

        public OpenLabel()
        {
            SizeChanged += (sender, args) =>
            {
                ElementBounds = Bounds;
            };
        }

        public Size Constraint
        {
            private set { SetValue(ConstraintKey, value); }
            get { return (Size)GetValue(ConstraintProperty); }
        }

        public SizeRequest SizeRequest
        {
            private set { SetValue(SizeRequestKey, value); }
            get { return (SizeRequest)GetValue(SizeRequestProperty); }
        }
        public Rectangle ElementBounds
        {
            private set { SetValue(ElementBoundsKey, value); }
            get { return (Rectangle)GetValue(ElementBoundsProperty); }
        }

        public override SizeRequest GetSizeRequest(double widthConstraint, double heightConstraint)
        {
            Constraint = new Size(widthConstraint, heightConstraint);
            SizeRequest sizeRequest = base.GetSizeRequest(widthConstraint, heightConstraint);
            SizeRequest = sizeRequest;
            return sizeRequest;
        }
    }
}
