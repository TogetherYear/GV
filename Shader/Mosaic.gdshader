shader_type canvas_item;

uniform float _Split:hint_range(1, 100, 1);

void fragment()
{
	vec2 pixelNum = vec2(textureSize(TEXTURE,0))/_Split;
	vec2 uv = floor(UV*pixelNum)/pixelNum;
	COLOR = texture(TEXTURE,uv);
}


