extends MeshInstance3D
class_name VoxelBlock

var color: Color

# Função para converter RGB (0-255) para Color (0-1)
func rgb_to_color(r: int, g: int, b: int) -> Color:
	r = clamp(r, 0, 255)
	g = clamp(g, 0, 255)
	b = clamp(b, 0, 255)
	
	return Color(r / 255.0, g / 255.0, b / 255.0)

func _init(
	_color: Color = Color(1, 1, 1),  # Default to white
	_position: Vector3 = Vector3.ZERO
	) -> void:
	self.position = _position
	self.color = _color
	self.mesh = BoxMesh.new()
	self.mesh.surface_set_material(0, StandardMaterial3D.new())
	self.mesh.surface_get_material(0).albedo_color = self.color
	self.scale = Vector3(0.25, 0.25, 0.25)
