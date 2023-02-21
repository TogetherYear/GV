shader_type canvas_item;

uniform sampler2D _Noise;
uniform float _Value:hint_range(0.0f, 1.0f) = 0.5f;

void fragment()
{
	vec4 color = texture(TEXTURE,UV);
	vec4 noiseColor = texture(_Noise,UV);
	if(noiseColor.r>_Value)
	{
		COLOR.a = 0.0f;
	}
	else
	{
		COLOR.a = 1.0f;
	}
}


