### Programmatic authenticated access to an arbitrary SP Online list.

#### Information
- utilizing the SP REST API we can export the contents of a list
- this allows for working with the data in a context outside of SharePoint, for example on a website that exposes specific internal information to outside users.
- Required packages:
  - `Install-Package Microsoft.SharePointOnline.CSOM`
  - `Install-Package Newtonsoft.Json`
