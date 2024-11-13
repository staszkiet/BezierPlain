3rd-Degree Bezier Surface Triangular Mesh Renderer
This project renders a 3rd-degree Bezier surface by interpolating it as a triangular mesh.
Users can manipulate surface orientation, lighting, and fill to explore both mesh wireframes and filled polygonal surfaces with lighting effects. 

Features:

Loads a 3rd-degree Bezier surface from a 16-line text file, where each line provides a control point in 3D (x, y, z) as:

X00 Y00 Z00
X01 Y01 Z01
...
X33 Y33 Z33
Where X0i is the first row of control points for Bezier's plain

Triangular Mesh Generation and Rotation

Generates a triangular mesh by interpolating the Bezier surface.
Users can rotate each mesh around the z-axis and x-axis by user-specified angles (α: -45° to 45°; β: 0° to 10°).

Allows toggling between mesh-only and filled-triangle views.
Adjusts mesh density through a triangulation accuracy slider.

Lighting and Shading Model:

Implements Lambertian shading with optional specular reflection

Object Color and Texture Mapping:

Supports two object color modes:
Solid color chosen from a menu.
Texture-mapped surface, where a texture image is loaded by user
Optionally modifies surface by using a normal map.
Animated Light Source

Light source follows a elliptic path on a fixed z-plane which can be stopped and resumed
