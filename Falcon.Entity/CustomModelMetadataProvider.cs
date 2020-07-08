using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace Falcon.Entity
{
    public class CustomModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(System.Collections.Generic.IEnumerable<System.Attribute> attributes, System.Type containerType, System.Func<object> modelAccessor, System.Type modelType, string propertyName)
        {
            var metadata = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);

            var renderModeAttribute = attributes.OfType<RenderModeAttribute>();
            if (renderModeAttribute.Any())
            {
                var renderMode = renderModeAttribute.First().RenderMode;
                switch (renderMode)
                {
                    case RenderMode.DisplayModeOnly:
                        metadata.ShowForDisplay = true;
                        metadata.ShowForEdit = false;
                        break;

                    case RenderMode.EditModeOnly:
                        metadata.ShowForDisplay = false;
                        metadata.ShowForEdit = true;
                        break;

                    case RenderMode.HideModelOnly:
                        metadata.ShowForDisplay = false;
                        metadata.ShowForEdit = false;
                        break;
                }
            }

            return metadata;
        }
    }
}
