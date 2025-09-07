extends Node3D

var block: VoxelBlock

# Função para converter RGB (0-255) para Color (0-1)
func rgb_to_color(r: int, g: int, b: int) -> Color:
	r = clamp(r, 0, 255)
	g = clamp(g, 0, 255)
	b = clamp(b, 0, 255)
	
	return Color(r / 255.0, g / 255.0, b / 255.0)

func _ready():
	# block = VoxelBlock.new(rgb_to_color(83, 33, 29))
	# self.add_child(block)
	pass
	
