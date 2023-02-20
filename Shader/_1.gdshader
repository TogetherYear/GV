shader_type canvas_item;

uniform sampler2D _Noise;
uniform float _Speed:hint_range(0.0f, 10.0f) = 1.0f;
uniform float _N:hint_range(0.0f, 10.0f) = 0.02f;

vec2 CUV(vec2 uv)
{
	return mod(uv,vec2(1.0f));
}

void fragment()
{
	vec3 noise = texture(_Noise,CUV(vec2(UV.x,UV.y-TIME*_Speed))).rgb;
	vec2 uv = UV + noise.rg*_N;
	COLOR.rgb = texture(TEXTURE,uv).rgb;
}


