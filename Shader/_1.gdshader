shader_type canvas_item;

uniform vec4 _Color:source_color;

void fragment()
{
	float value = distance(UV,vec2(0.5f,0.5f));
	vec3 texColor = texture(TEXTURE,UV).rgb;
	vec3 color = texColor + _Color.rgb*value;
	COLOR = vec4(color,1.0f);
}


